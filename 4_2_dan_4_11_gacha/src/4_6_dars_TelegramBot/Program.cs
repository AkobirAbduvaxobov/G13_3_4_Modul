using System.Collections.Concurrent;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;

namespace AnonymousChatBot;

class Program
{
    private static TelegramBotClient? _bot;

    // Userlarning holatini saqlash uchun: "idle" (bo'sh), "searching" (qidirmoqda), "chatting" (suhbatda)
    private static readonly ConcurrentDictionary<long, string> _userStates = new();

    // Suhbatlashayotgan juftliklarni saqlash (User1 -> User2 va User2 -> User1)
    private static readonly ConcurrentDictionary<long, long> _activeChats = new();

    // Suhbatdosh kutayotganlar navbati
    private static readonly ConcurrentQueue<long> _waitingQueue = new();

    // ==========================================
    // KEYBOARD (TUGMALAR) MENYULARI
    // ==========================================
    private static readonly ReplyKeyboardMarkup MainMenu = new(new[]
    {
        new KeyboardButton[] { "🔍 Suhbatdosh izlash" }
    })
    { ResizeKeyboard = true };

    private static readonly ReplyKeyboardMarkup CancelMenu = new(new[]
    {
        new KeyboardButton[] { "🚫 Bekor qilish" }
    })
    { ResizeKeyboard = true };

    private static readonly ReplyKeyboardMarkup ChatMenu = new(new[]
    {
        new KeyboardButton[] { "❌ Suhbatni yakunlash" },
        new KeyboardButton[] { "🔄 Boshqasini topish" }
    })
    { ResizeKeyboard = true };

    static async Task Main()
    {
        _bot = new TelegramBotClient("8789314079:AAHpcvkZHmXD4WQKrdUMJOP44lKQAeXfgm4");

        using var cts = new CancellationTokenSource();
        var receiverOptions = new ReceiverOptions { AllowedUpdates = [] };

        _bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken: cts.Token);

        Console.WriteLine("Anonim bot ishga tushdi...");
        Console.ReadLine();
        cts.Cancel();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        // Faqat xabarlarni qabul qilamiz
        if (update.Type == UpdateType.Message && update.Message != null)
        {
            await HandleMessageAsync(update.Message, ct);
        }
    }

    private static async Task HandleMessageAsync(Message message, CancellationToken ct)
    {
        var chatId = message.Chat.Id;
        var text = message.Text;

        // Userning joriy holatini olamiz (agar bazada bo'lmasa "idle" deb oladi)
        var state = _userStates.GetValueOrDefault(chatId, "idle");

        // /start bosilganda har doim holatni yangilaymiz
        if (text == "/start")
        {
            await DisconnectChat(chatId, ct); // Agar suhbatda bo'lsa uzamiz
            _userStates[chatId] = "idle";
            await _bot!.SendMessage(chatId, "Assalomu alaykum! Anonim chatga xush kelibsiz.\nSuhbat boshlash uchun pastdagi tugmani bosing.", replyMarkup: MainMenu, cancellationToken: ct);
            return;
        }

        // Holatga qarab xabarlarni boshqarish
        switch (state)
        {
            case "idle":
                if (text == "🔍 Suhbatdosh izlash")
                    await StartSearch(chatId, ct);
                else
                    await _bot!.SendMessage(chatId, "Iltimos, menyudan foydalaning 👇", replyMarkup: MainMenu, cancellationToken: ct);
                break;

            case "searching":
                if (text == "🚫 Bekor qilish")
                    await CancelSearch(chatId, ct);
                else
                    await _bot!.SendMessage(chatId, "Suhbatdosh qidirilmoqda... Iltimos kuting yoki bekor qiling.", replyMarkup: CancelMenu, cancellationToken: ct);
                break;

            case "chatting":
                if (text == "❌ Suhbatni yakunlash")
                {
                    await DisconnectChat(chatId, ct);
                    await _bot!.SendMessage(chatId, "Suhbat yakunlandi. Bosh menudasiz.", replyMarkup: MainMenu, cancellationToken: ct);
                }
                else if (text == "🔄 Boshqasini topish")
                {
                    await DisconnectChat(chatId, ct);
                    await StartSearch(chatId, ct);
                }
                else
                {
                    // Suhbatdoshga xabarni jo'natish (Matn, rasm, stiker barchasi ishlaydi)
                    await ForwardToPartner(chatId, message, ct);
                }
                break;
        }
    }

    // ==========================================
    // ASOSIY MANTIQIY FUNKSIYALAR
    // ==========================================

    private static async Task StartSearch(long chatId, CancellationToken ct)
    {
        _userStates[chatId] = "searching";
        await _bot!.SendMessage(chatId, "Suhbatdosh qidirilmoqda... ⏳", replyMarkup: CancelMenu, cancellationToken: ct);

        // Navbatda odam bormi tekshiramiz
        while (_waitingQueue.TryDequeue(out var partnerId))
        {
            // Agar sherik topilsa va u hamon "searching" holatida bo'lsa
            if (partnerId != chatId && _userStates.GetValueOrDefault(partnerId) == "searching")
            {
                // Ikkalasini biriktiramiz
                _activeChats[chatId] = partnerId;
                _activeChats[partnerId] = chatId;

                _userStates[chatId] = "chatting";
                _userStates[partnerId] = "chatting";

                await _bot.SendMessage(chatId, "Suhbatdosh topildi! Suhbatni boshlashingiz mumkin. 🎉", replyMarkup: ChatMenu, cancellationToken: ct);
                await _bot.SendMessage(partnerId, "Suhbatdosh topildi! Suhbatni boshlashingiz mumkin. 🎉", replyMarkup: ChatMenu, cancellationToken: ct);
                return;
            }
        }

        // Agar navbatda hech kim bo'lmasa, o'zini navbatga qo'shadi
        _waitingQueue.Enqueue(chatId);
    }

    private static async Task CancelSearch(long chatId, CancellationToken ct)
    {
        _userStates[chatId] = "idle";
        await _bot!.SendMessage(chatId, "Qidiruv bekor qilindi.", replyMarkup: MainMenu, cancellationToken: ct);
    }

    private static async Task DisconnectChat(long chatId, CancellationToken ct)
    {
        if (_activeChats.TryRemove(chatId, out var partnerId))
        {
            // Sherigining ulanishini ham o'chiramiz
            _activeChats.TryRemove(partnerId, out _);

            // Ikkalasini ham bo'sh holatga o'tkazamiz
            _userStates[chatId] = "idle";
            _userStates[partnerId] = "idle";

            try
            {
                await _bot!.SendMessage(partnerId, "Suhbatdosh suhbatni tark etdi. 😔", replyMarkup: MainMenu, cancellationToken: ct);
            }
            catch { /* Agar sherik botni bloklagan bo'lsa xatolik bermasligi uchun */ }
        }
    }

    private static async Task ForwardToPartner(long senderId, Message message, CancellationToken ct)
    {
        if (_activeChats.TryGetValue(senderId, out var partnerId))
        {
            try
            {
                // CopyMessage orqali tekst, rasm, video, stiker - nima bo'lsa ham sherikka yuboriladi
                await _bot!.CopyMessage(
                    chatId: partnerId,
                    fromChatId: senderId,
                    messageId: message.MessageId,
                    cancellationToken: ct
                );
            }
            catch
            {
                await DisconnectChat(senderId, ct);
                await _bot!.SendMessage(senderId, "Suhbatdoshingiz botni bloklagan ko'rinadi. Suhbat yakunlandi.", replyMarkup: MainMenu, cancellationToken: ct);
            }
        }
    }

    private static Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken ct)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiReqException => $"Telegram API xatosi: {apiReqException.Message}",
            _ => exception.ToString()
        };
        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }
}