namespace SocialMedia.Api.Entities;

public class Comment
{
    public Guid CommentId { get; set; }
    public string Content { get; set; }
    public Guid PostId { get; set; }
    public Guid? ReplyId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
