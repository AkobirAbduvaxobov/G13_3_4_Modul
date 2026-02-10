namespace SocialMedia.Api.Services;

public interface ITokenService
{
    public (Guid userId, string role) GetTokenInfo(string token);
}