namespace _4_7_dars_Bot_davomi;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;

public class Program
{
    private static ITelegramBotClient _bot;
    private static string BotToken = "8789314079:AAHpcvkZHmXD4WQKrdUMJOP44lKQAeXfgm4";
    static async Task Main(string[] args)
    {
        _bot = new TelegramBotClient(BotToken);

        _bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync);

        Console.WriteLine("Anonim bot ishga tushdi...");
        Console.ReadLine();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        var chatId = update.Message.Chat.Id;
        var name = update.Message.Chat.FirstName;
        //var data = update.CallbackQuery.Data;

        if(update.CallbackQuery != null)
        {
            
        }

        if (update.Message.Type == MessageType.Text && update.Message.Text.ToLower() == "/start")
        {
            await _bot.SendMessage(chatId, $"Botga xush kelibsiz nma yordam kk {name}");
        }

        else if(update.Message.Text.ToLower() == "inline")
        {
            var inline = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("About", "About"),
                InlineKeyboardButton.WithCallbackData("Help", "Data")
            });

            await bot.SendMessage(
                chatId,
                "Tanlang:",
                replyMarkup: inline
            );
        }
        

        else if(update.Message.Type == MessageType.Photo)
        {

            ReplyKeyboardMarkup MainMenu = new(new[]
            {
                new KeyboardButton[] { ".pdf" },
                new KeyboardButton[] { ".word" },
                new KeyboardButton[] { ".exel" }
            })
            { ResizeKeyboard = true };

            await _bot.SendMessage(chatId, $"Rasm qaysi formatga o'tkazaylik", replyMarkup : MainMenu);
        }
        
        //if (update.Type == UpdateType.Message && update.Message != null)
        //{
            
        //}
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
