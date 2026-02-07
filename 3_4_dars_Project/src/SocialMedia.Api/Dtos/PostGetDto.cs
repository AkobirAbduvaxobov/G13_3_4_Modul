
namespace SocialMedia.Api.Dtos;

public class PostGetDto
{
    public Guid PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public Guid UserId { get; set; }
}
