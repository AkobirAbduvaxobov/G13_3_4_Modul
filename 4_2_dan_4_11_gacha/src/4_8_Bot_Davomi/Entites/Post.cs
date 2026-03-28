namespace _4_8_Bot_Davomi.Entites;

public class Post
{
    public long PostId { get; set; }
    public long ChatId { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
}
