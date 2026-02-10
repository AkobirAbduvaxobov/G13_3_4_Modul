using SocialMedia.Api.Dtos;

namespace SocialMedia.Api.Services;

public interface ICommentService
{
    public Guid Add(CommentCreateDto commentCreateDto, string token);
    public bool Delete(Guid id, string token);
    public List<CommentGetDto> GetAll(string token);
    public bool Update(Guid commentId, CommentUpdateDto commentUpdateDto, string token);
    public List<CommentGetDto> GetCommentsByPostId(Guid postId, string token);
    public List<CommentGetDto> GetReplyComments(Guid commentId, string token);
}