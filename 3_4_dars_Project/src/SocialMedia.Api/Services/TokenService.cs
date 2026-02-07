using SocialMedia.Api.Repositories;

namespace SocialMedia.Api.Services;

public class TokenService : ITokenService
{
    private readonly IUserRepository UserRepository;
    public TokenService()
    {
        UserRepository = new UserRepository();
    }
    public (string userId, string role) GetTokenInfo(string token)
    {
        var userId = token.Substring(0, 36);
        var role = token.Substring(36);

        return (userId, role);
    }
}
