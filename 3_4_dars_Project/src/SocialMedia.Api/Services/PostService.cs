using Microsoft.Extensions.Hosting;
using SocialMedia.Api.Dtos;
using SocialMedia.Api.Entities;
using SocialMedia.Api.Repositories;

namespace SocialMedia.Api.Services;
public class PostService : IPostService
{
    private readonly IPostRepository PostRepository;
    private readonly ITokenService TokenService;
    private readonly IUserRepository UserRepository;
    public PostService()
    {
        PostRepository = new PostRepository();
        TokenService = new TokenService();
        UserRepository = new UserRepository();
    }


    public Guid AddPost(PostCreateDto postCreateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        

        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return Guid.Empty;
        }

        var post = new Post()
        {
            PostId = Guid.NewGuid(),
            Title = postCreateDto.Title,
            Content = postCreateDto.Content,
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            UserId = Guid.Parse(tokenResult.userId)
        };

        var userExists = false;
        var users = UserRepository.GetAllUsers();
        foreach (var user in users)
        {
            if (user.UserId.ToString() == tokenResult.userId)
            {
                userExists = true;
                break;
            }
        }

        if (userExists == true)
        {
            var posts = PostRepository.GetAllPosts();
            posts.Add(post);
            PostRepository.SaveAllPosts(posts);
        }

        return post.PostId;
    }

    public bool DeletePost(Guid postId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return false;
        }

        var posts = PostRepository.GetAllPosts();

        foreach (var post in posts)
        {
            if (post.PostId == postId && post.UserId.ToString() == tokenResult.userId)
            {
                posts.Remove(post);
                PostRepository.SaveAllPosts(posts);
                return true;
            }
        }

        return false;
    }

    public List<PostGetDto> GetAllPosts(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var postGetDtos = new List<PostGetDto>();

        var posts = PostRepository.GetAllPosts();

        //var countOfPosts = posts.Count(p => p.UserId.ToString() == tokenResult.userId);

        //var userPosts = posts.Where(p => p.UserId.ToString() == tokenResult.userId).ToList();

        //var userPostDtos = userPosts.Select(p => new PostGetDto()
        //{
        //    PostId = p.PostId,
        //    Title = p.Title,
        //    Content = p.Content,
        //    CreatedTime = p.CreatedTime,
        //    UpdatedTime = p.UpdatedTime,
        //    UserId = p.UserId
        //}).ToList();

        foreach (var post in posts)
        {
            if (post.UserId.ToString() == tokenResult.userId)
            {
                var postGetDto = new PostGetDto()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Content = post.Content,
                    CreatedTime = post.CreatedTime,
                    UpdatedTime = post.UpdatedTime,
                    UserId = post.UserId
                };
                postGetDtos.Add(postGetDto);
            }
        }

        postGetDtos = postGetDtos.OrderBy(p => p.CreatedTime).ToList();
        postGetDtos = postGetDtos.OrderByDescending(p => p.CreatedTime).ToList();



        return postGetDtos;
    }

    public List<PostGetDto>? GetAllPostsByAdmin(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        if (tokenResult.role == "User")
        {
            return null;
        }

        var posts = PostRepository.GetAllPosts();

        var postGetDtos = new List<PostGetDto>();
        foreach (var post in posts)
        {
            var postGetDto = new PostGetDto()
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                CreatedTime = post.CreatedTime,
                UpdatedTime = post.UpdatedTime
            };
            postGetDtos.Add(postGetDto);
        }

        return postGetDtos;
    }

    public PostGetDto? GetPostById(Guid postId)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePost(Guid postId, PostCreateDto postCreateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(Guid.Parse(tokenResult.userId));

        if (userBlocked == true)
        {
            return false;
        }

        var posts = PostRepository.GetAllPosts();   

        foreach (var post in posts)
        {
            if (post.PostId == postId && post.UserId.ToString() == tokenResult.userId)
            {
                post.Title = postCreateDto.Title;
                post.Content = postCreateDto.Content;
                post.UpdatedTime = DateTime.Now;
                PostRepository.SaveAllPosts(posts);
                return true;
            }
        }

        return false;
    }
}
