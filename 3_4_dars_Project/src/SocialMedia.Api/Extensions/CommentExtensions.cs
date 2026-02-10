using SocialMedia.Api.Dtos;
using SocialMedia.Api.Entities;

namespace SocialMedia.Api.Extensions;

public static class CommentExtensions
{
    public static Comment ToEntity(this CommentCreateDto commentCreateDto)
    {
        return new Comment
        {
            Content = commentCreateDto.Content,
            PostId = commentCreateDto.PostId,
            ReplyId = commentCreateDto.ReplyId,
        };
    }

    public static Comment ToEntity(this CommentUpdateDto commentUpdateDto)
    {
        return new Comment
        {
            Content = commentUpdateDto.Content,
            PostId = commentUpdateDto.PostId,
            ReplyId = commentUpdateDto.ReplyId,
        };
    }

    public static CommentGetDto ToDto(this Comment comment)
    {
        return new CommentGetDto
        {
            CommentId = comment.CommentId,
            ReplyId = comment.ReplyId,
            UserId = comment.UserId,
            PostId = comment.PostId,
            Content = comment.Content,
            CreateAt = comment.CreateAt,
            UpdateAt = comment.UpdateAt
        };
    }
}
