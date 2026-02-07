using SocialMedia.Api.Entities;

namespace SocialMedia.Api.Repositories;

public interface IPostRepository
{
    public List<Post>? GetAllPosts();
    public void SaveAllPosts(List<Post> posts);
}