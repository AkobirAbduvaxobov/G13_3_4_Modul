using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Dtos;
using SocialMedia.Api.Services;

namespace SocialMedia.Api.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentService CommentService;
    public CommentsController()
    {
        CommentService = new CommentService();
    }

    [HttpPost("add")]
    public Guid Add(CommentCreateDto commentCreateDto, string token)
    {
        return CommentService.Add(commentCreateDto, token);
    }

    [HttpDelete("delete")]
    public bool Delete(Guid id, string token)
    {
        return CommentService.Delete(id, token);
    }

    [HttpGet("get-all")]
    public List<CommentGetDto> GetAll(string token)
    {
        return CommentService.GetAll(token);
    }
}
