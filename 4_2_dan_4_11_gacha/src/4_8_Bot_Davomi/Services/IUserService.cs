using _4_8_Bot_Davomi.Dtos;
using _4_8_Bot_Davomi.Entites;

namespace _4_8_Bot_Davomi.Services;

public interface IUserService
{
    public Task<string> AddAsync(BotUser user);
    public Task AddPhoneNUmberAsync(string phoneNumber);
    public Task<List<UserGetDto>> GetAllAsync(long chatId);
    public Task<List<UserGetDto>> GetAllFollowersAsync(long chatId);
    public Task<List<UserGetDto>> GetAllFollowingsAsync(long chatId);
    public Task<List<UserGetDto>> SearchWithUserNameAsync(long chatId, string userName);
}