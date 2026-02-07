using SocialMedia.Api.Dtos;

namespace SocialMedia.Api.Services;

public interface IPostService
{
    public Guid AddPost(PostCreateDto postCreateDto, string token);
    public List<PostGetDto> GetAllPosts(string token);
    public List<PostGetDto>? GetAllPostsByAdmin(string token);
    public PostGetDto? GetPostById(Guid postId);
    public bool DeletePost(Guid postId, string token);
    public bool UpdatePost(Guid postId, PostCreateDto postCreateDto, string token);
}