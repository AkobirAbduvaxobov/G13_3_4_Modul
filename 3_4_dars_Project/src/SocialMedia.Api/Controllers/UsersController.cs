using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Dtos;
using SocialMedia.Api.Services;

namespace SocialMedia.Api.Controllers;

[Route("api/admin")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService UserService;
    public UsersController()
    {
        UserService = new UserService();
    }

    [HttpGet("get-all")]
    public List<UserGetDto>? GetAll(string token)
    {
        return UserService.GetAllUsers(token);
    }

    [HttpDelete("delete")]
    public bool DeleteUser(Guid userId, string token)
    {
        return UserService.DeleteUser(userId, token);
    }

    [HttpDelete("delete-user-post")]
    public bool DeleteUserPost(Guid postId, string token)
    {
        return UserService.DeleteUserPost(postId, token);
    }

    [HttpPut("block")]
    public bool BlockUser(Guid userId, string token)
    {
        return UserService.BlockUser(userId, token);
    }

    [HttpPut("change-role")]
    public bool ChangeRole(Guid userId, string newRole, string token)
    {
        return UserService.ChangeRole(userId, newRole, token);

    }
}
