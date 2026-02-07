using SocialMedia.Api.Dtos;
using SocialMedia.Api.Repositories;

namespace SocialMedia.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository UserRepository;
    private readonly ITokenService TokenService;
    private readonly IPostRepository PostRepository;

    public UserService()
    {
        PostRepository = new PostRepository();
        TokenService = new TokenService();
        UserRepository = new UserRepository();
    }

    public bool BlockUser(Guid userId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        var users = UserRepository.GetAllUsers();

        foreach (var user in users)
        {
            if (user.UserId == userId)
            {
                user.UserBlocked = !user.UserBlocked;
                UserRepository.SaveAllUsers(users);
                return true;
            }
        }

        return false;
    }

    public bool ChangeRole(Guid userId, string newRole, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        if (tokenResult.role != "SuperAdmin")
        {
            return false;
        }

        var users = UserRepository.GetAllUsers();

        foreach (var user in users)
        {
            if (user.UserId == userId)
            {
                user.UserRole = newRole;
                UserRepository.SaveAllUsers(users);
                return true;
            }
        }

        return false;
    }

    public bool DeleteUser(Guid userId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        var users = UserRepository.GetAllUsers();   

        foreach (var user in users)
        {
            if (user.UserId == userId)
            {
                users.Remove(user);
                UserRepository.SaveAllUsers(users);
                return true;
            }
        }

        return false;
    }

    public bool DeleteUserPost(Guid postId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return false;
        }

        var posts = PostRepository.GetAllPosts();   

        foreach (var post in posts)
        {
            if (post.PostId == postId)
            {
                posts.Remove(post);
                PostRepository.SaveAllPosts(posts);
                return true;
            }
        }

        return false;
    }

    public List<UserGetDto>? GetAllUsers(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        if (tokenResult.role == "User")
        {
            return null;
        }

        var users = UserRepository.GetAllUsers();
        var userDtos = new List<UserGetDto>();
        foreach (var user in users)
        {
            var userDto = new UserGetDto()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                UserRole = user.UserRole,
                UserBlocked = user.UserBlocked,
                RegisterTime = user.RegisterTime
            };
            userDtos.Add(userDto);
        }

        return userDtos;
    }
}
