using _4_8_Bot_Davomi.Dtos;
using _4_8_Bot_Davomi.Entites;
using _4_8_Bot_Davomi.Repositories;

namespace _4_8_Bot_Davomi.Services;

public class UserService : IUserService
{
    private readonly IRepository<BotUser> UserRepository;
    private readonly IRepository<UserConnections> UserConnectionsRepository;

    public UserService()
    {
        UserRepository = new Repository<BotUser>();
        UserConnectionsRepository = new Repository<UserConnections>();
    }

    public async Task<string> AddAsync(BotUser user)
    {
        var users = await UserRepository.GetAllAsync();
        if (user.Username == null)
        {
            user.Username = $"@user{Guid.NewGuid}";
        }

        users.Add(user);
        await UserRepository.SaveAllAsync(users);
        return user.Username;   
    }

    public async Task<List<UserGetDto>> GetAllAsync(long chatId)
    {
        var usersTask = UserRepository.GetAllAsync();
        var followersIdTask = GetFollowersIdAsync(chatId); // 3,4,5
        var followingsIdTask = GetFollowingsIdAsync(chatId); // 3,5

        await Task.WhenAll(usersTask, followersIdTask, followingsIdTask);

        var users = usersTask.Result;
        var followersId = followersIdTask.Result;
        var followingsId = followingsIdTask.Result;


        var userGetDtos = new List<UserGetDto>();

        foreach (var user in users)
        {
            userGetDtos.Add(new UserGetDto()
            {
                UserName = user.Username,
                IsFollower = followersId.Contains(user.ChatId),
                IsFollowing = followingsId.Contains(user.ChatId),
            });
        }

        return userGetDtos;
    }

    public async Task<List<UserGetDto>> GetAllFollowersAsync(long chatId) // 2
    {
        var usersTask = UserRepository.GetAllAsync();
        var followersIdTask = GetFollowersIdAsync(chatId); // 3,4,5
        var followingsIdTask = GetFollowingsIdAsync(chatId); // 3,5

        await Task.WhenAll(usersTask, followersIdTask, followingsIdTask);

        var users = usersTask.Result;
        var followersId = followersIdTask.Result;
        var followingsId = followingsIdTask.Result;

        var followers = users.Where(u => followersId.Contains(u.ChatId)).ToList();

        var userGetDtos = new List<UserGetDto>();   

        foreach(var follower in followers)
        {
            userGetDtos.Add(new UserGetDto()
            {
                UserName = follower.Username,
                IsFollower = true,
                IsFollowing = followingsId.Contains(follower.ChatId),
            });
        }

        return userGetDtos;
    }

    private async Task<List<long>> GetFollowersIdAsync(long chatId)
    {
        var userConnections = await UserConnectionsRepository.GetAllAsync();

        var followersId = userConnections
            .Where(uc => uc.ChatId == chatId)
            .Select(uc => uc.FollowerId).ToList();

        return followersId;
    }

    private async Task<List<long>> GetFollowingsIdAsync(long chatId)
    {
        var userConnections = await UserConnectionsRepository.GetAllAsync();

        var followingsId = userConnections
            .Where(uc => uc.FollowerId == chatId)
            .Select(uc => uc.ChatId).ToList();

        return followingsId;
    }

    public async Task<List<UserGetDto>> GetAllFollowingsAsync(long chatId)
    {
        var usersTask = UserRepository.GetAllAsync();
        var followersIdTask = GetFollowersIdAsync(chatId); // 3,4,5
        var followingsIdTask = GetFollowingsIdAsync(chatId); // 3,5

        await Task.WhenAll(usersTask, followersIdTask, followingsIdTask);

        var users = usersTask.Result;
        var followersId = followersIdTask.Result;
        var followingsId = followingsIdTask.Result;

        var followings = users.Where(u => followingsId.Contains(u.ChatId)).ToList();

        var userGetDtos = new List<UserGetDto>();

        foreach (var follower in followings)
        {
            userGetDtos.Add(new UserGetDto()
            {
                UserName = follower.Username,
                IsFollower = followersId.Contains(follower.ChatId),
                IsFollowing = true,
            });
        }

        return userGetDtos;
    }

    public async Task<List<UserGetDto>> SearchWithUserNameAsync(long chatId, string userName)
    {
        var users = await GetAllAsync(chatId);
        var userGetDtos = users
            .Where(u => u.UserName.StartsWith(userName))
            .ToList();

        return userGetDtos;
    }

    public Task AddPhoneNUmberAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }
}
