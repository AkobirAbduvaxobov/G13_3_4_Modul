using SocialMedia.Api.Entities;

namespace SocialMedia.Api.Repositories;

public interface ICommentRepository
{
    public List<Comment>? GetAllComments();
    public void SaveAllComments(List<Comment> comments);
}