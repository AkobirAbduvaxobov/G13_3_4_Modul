using SocialMedia.Api.Dtos;

namespace SocialMedia.Api.Services;

public interface IPostService
{
    List<PostGetDto> GetAllPosts();
    PostGetDto? GetPostById(Guid postId);
    Guid CreatePost(PostCreateDto postCreateDto);
    bool UpdatePost(Guid postId, PostUpdateDto postUpdateDto);
    bool DeletePost(Guid postId);
}