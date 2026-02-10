using SocialMedia.Api.Dtos;
using SocialMedia.Api.Extensions;
using SocialMedia.Api.Repositories;

namespace SocialMedia.Api.Services;

public class CommentService : ICommentService
{
    private readonly IPostRepository PostRepository;
    private readonly ITokenService TokenService;
    private readonly IUserRepository UserRepository;
    private readonly ICommentRepository CommentRepository;

    public CommentService()
    {
        PostRepository = new PostRepository();
        TokenService = new TokenService();
        UserRepository = new UserRepository();
        CommentRepository = new CommentRepository();
    }

    public Guid Add(CommentCreateDto commentCreateDto, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);

        var userBlocked = UserRepository.UserBlocked(tokenResult.userId);

        if (userBlocked == true)
        {
            return Guid.Empty;
        }

        var userExists = UserRepository.UserExists(tokenResult.userId);

        if(!userExists)
        {
            return Guid.Empty;
        }

        var now = DateTime.UtcNow;

        var comment = commentCreateDto.ToEntity();
        comment.CommentId = Guid.NewGuid();
        comment.CreateAt = now;
        comment.UpdateAt = now;
        comment.UserId = tokenResult.userId;

        var comments = CommentRepository.GetAllComments();
        comments.Add(comment);
        CommentRepository.SaveAllComments(comments);
        return comment.CommentId;
    }

    public bool Delete(Guid id, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userRole = tokenResult.role;
        var isAdmin = userRole == "Admin" || userRole == "SuperAdmin";


        var comments = CommentRepository.GetAllComments();

        foreach(var c in comments)
        {
            if(c.CommentId == id && c.UserId == tokenResult.userId || isAdmin && c.CommentId == id)
            {
                comments.Remove(c);
                CommentRepository.SaveAllComments(comments);
                return true;
            }
        }

        return false;
    }

    public List<CommentGetDto> GetAll(string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userRole = tokenResult.role;

        var comments = CommentRepository.GetAllComments();

        if (userRole == "Admin" || userRole == "SuperAdmin")
        {
            return comments.Select(c => c.ToDto()).ToList();
        }

        return comments
            .Where(c => c.UserId == tokenResult.userId)
            .Select(c => c.ToDto())
            .ToList();
    }

    public List<CommentGetDto> GetCommentsByPostId(Guid postId, string token)
    {
        var tokenResult = TokenService.GetTokenInfo(token);
        var userRole = tokenResult.role;

        var posts = PostRepository.GetAllPosts();

        var post = posts.FirstOrDefault(p => p.UserId == tokenResult.userId);

        if(post == null)
        {
            return new List<CommentGetDto>();
        }

        var comments = CommentRepository.GetAllComments();
        return comments
            .Where(c => c.PostId == post.PostId)
            .Select(c => c.ToDto())
            .ToList();
    }

    public List<CommentGetDto> GetReplyComments(Guid commentId, string token)
    {
        throw new NotImplementedException();
    }

    public bool Update(Guid commentId, CommentUpdateDto commentUpdateDto, string token)
    {
        throw new NotImplementedException();
    }
}
