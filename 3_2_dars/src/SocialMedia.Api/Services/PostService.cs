using SocialMedia.Api.Dtos;
using SocialMedia.Api.Entities;
using System.Text.Json;

namespace SocialMedia.Api.Services;

public class PostService : IPostService
{
    private List<Post> Posts;
    // readonly vs const
    private readonly string FilePath;
    public PostService()
    {
        FilePath = "D:\\Work\\Groups\\G_13\\Moduls\\G13_3_4_Modul\\3_2_dars\\src\\SocialMedia.Api\\AppDBContext\\Data.json";
        Posts = new List<Post>();
        
    }
    public Guid CreatePost(PostCreateDto postCreateDto)
    {
        ReadPostsFromFile();
        Post post = new Post()
        {
            PostId = Guid.NewGuid(),
            Title = postCreateDto.Title,
            Content = postCreateDto.Content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UserId = postCreateDto.UserId
        };

        Posts.Add(post);
        SavePostsToFile();
        return post.PostId;
    }

    public bool DeletePost(Guid postId)
    {
        ReadPostsFromFile();
        foreach (var post in Posts)
        {
            if (post.PostId == postId)
            {
                Posts.Remove(post);
                SavePostsToFile();
                return true;
            }
        }

        return false;
    }

    public List<PostGetDto> GetAllPosts()
    {
        ReadPostsFromFile();
        List<PostGetDto> postGetDtos = new List<PostGetDto>();
        foreach (var p in Posts)
        {
            postGetDtos.Add(new PostGetDto()
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                UserId = p.UserId
            });
        }

        return postGetDtos;
    }

    public PostGetDto? GetPostById(Guid postId)
    {
        ReadPostsFromFile();
        foreach (var p in Posts)
        {
            if (p.PostId == postId)
            {
                return new PostGetDto()
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    UserId = p.UserId
                };
            }
        }

        return null;
    }

    public bool UpdatePost(Guid postId, PostUpdateDto postUpdateDto)
    {
        ReadPostsFromFile();
        foreach (var p in Posts)
        {
            if (p.PostId == postId)
            {
                p.Title = postUpdateDto.Title;
                p.Content = postUpdateDto.Content;
                p.UpdatedAt = DateTime.UtcNow;
                SavePostsToFile();
                return true;
            }
        }

        return false;
    }

    private void SavePostsToFile()
    {
        var json = JsonSerializer.Serialize(Posts);
        File.WriteAllText(FilePath, json);
    }

    private void ReadPostsFromFile()
    {
        var json = File.ReadAllText(FilePath);

        if(string.IsNullOrEmpty(json))
        {
            Posts = new List<Post>();
            return;
        }

        Posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
    }
}
