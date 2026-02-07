using Microsoft.AspNetCore.Http;
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

    [HttpPost("add")]
    public Guid Create(PostCreateDto postCreateDto, string token)
    {
        return PostService.AddPost(postCreateDto, token);
    }

    [HttpGet("get-all")]
    public List<PostGetDto> GetAll(string token)
    {
        return PostService.GetAllPosts(token);
    }

    [HttpGet("get-all-by-admin")]
    public List<PostGetDto>? GetAllByAdmin(string token)
    {
        return PostService.GetAllPostsByAdmin(token);
    }

    [HttpGet("get-by-id")]
    public PostGetDto? GetById(Guid postId)
    {
        return PostService.GetPostById(postId);
    }

    [HttpDelete("delete")]
    public bool Delete(Guid postId, string token)
    {
        return PostService.DeletePost(postId, token);
    }

    [HttpPut("update")]
    public bool Update(Guid postId, PostCreateDto postCreateDto, string token)
    {
        return PostService.UpdatePost(postId, postCreateDto, token);
    }
}
