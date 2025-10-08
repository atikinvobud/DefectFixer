using System.Runtime.CompilerServices;
using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class CommentExtension
{
    public static CommentEntity ToEntity(this PostComment postComment)
    {
        return new CommentEntity()
        {
            DefectId = postComment.DefectId,
            CreatedAt = DateTime.Now,
            Text = postComment.Text,
            AuthorId = postComment.AuthorId
        };
    }
    public static GetComment ToDTO(this CommentEntity entity)
    {
        return new GetComment()
        {
            Id = entity.Id,
            DefectId = entity.DefectId,
            CreatedAt = entity.CreatedAt,
            Text = entity.Text,
            FullName =entity.userEntity!.UserInfoEntity!.Name + " " + entity.userEntity!.UserInfoEntity!.Surname
        };
    }
    public static void Update(this CommentEntity entity, PutComment putComment)
    {
        entity.DefectId = putComment.DefectId ?? entity.DefectId;
        entity.CreatedAt = DateTime.Now;
        entity.Text = putComment.Text ?? entity.Text;
        entity.AuthorId = putComment.AuthorId ?? entity.AuthorId;
    }
}