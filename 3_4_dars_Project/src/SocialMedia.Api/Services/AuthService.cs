using SocialMedia.Api.Dtos;
using SocialMedia.Api.Entities;
using SocialMedia.Api.Repositories;

namespace SocialMedia.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository UserRepository;
    public AuthService()
    {
        UserRepository = new UserRepository();
    }

    public string LoginUser(UserLoginDto userLoginDto)
    {
        var users = UserRepository.GetAllUsers();

        foreach (var user in users)
        {
            if (user.UserName == userLoginDto.UserName
                && user.Password == userLoginDto.Password)
            {
                return user.UserId.ToString() + user.UserRole;
            }
        }

        return "User yoki parol xato";
    }

    public Guid RegisterUser(UserRegisterDto userRegisterDto)
    {
        var user = new User()
        {
            UserId = Guid.NewGuid(),
            FirstName = userRegisterDto.FirstName,
            LastName = userRegisterDto.LastName,
            UserName = userRegisterDto.UserName,
            Password = userRegisterDto.Password,
            UserRole = "User",
            UserBlocked = false,
            RegisterTime = DateTime.Now
        };

        var users = UserRepository.GetAllUsers();

        users.Add(user);

        UserRepository.SaveAllUsers(users);

        return user.UserId;
    }
}
