using SocialMedia.Api.Entities;

namespace SocialMedia.Api.Repositories;

public interface IUserRepository
{
    public List<User>? GetAllUsers();
    public void SaveAllUsers(List<User> users);
    public bool? UserBlocked(Guid userId);
}