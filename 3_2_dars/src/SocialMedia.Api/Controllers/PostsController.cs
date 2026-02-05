using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Dtos;
using SocialMedia.Api.Services;

namespace SocialMedia.Api.Controllers;

[Route("api/posts")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostService PostService;
    public PostsController()
    {
        PostService = new PostService();
    }

    [HttpPost("create")]
    public Guid Create(PostCreateDto postCreateDto)
    {
        var postId = PostService.CreatePost(postCreateDto);
        return postId;
    }

    [HttpGet("get-all")]
    public List<PostGetDto> GetAll()
    {
        return PostService.GetAllPosts();
    }

    [HttpGet("get-by-id")]
    public PostGetDto? GetById(Guid postId)
    {
        return PostService.GetPostById(postId);
    }

    [HttpDelete("delete")]
    public bool Delete(Guid postId)
    {
        return PostService.DeletePost(postId);
    }

    [HttpPut]
    public bool Update(Guid postId, PostUpdateDto postUpdateDto)
    {
        return PostService.UpdatePost(postId, postUpdateDto);
    }
}
