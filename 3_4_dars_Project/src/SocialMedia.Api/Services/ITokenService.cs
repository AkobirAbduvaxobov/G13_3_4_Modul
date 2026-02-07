namespace SocialMedia.Api.Services;

public interface ITokenService
{
    public (string userId, string role) GetTokenInfo(string token);
}