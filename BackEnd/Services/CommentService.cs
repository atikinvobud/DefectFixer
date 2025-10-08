using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Models.Entities;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository commentRepository;
    public CommentService(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }

    public async Task<int> Create(PostComment postComment)
    {
        CommentEntity comment = postComment.ToEntity();
        int id = await commentRepository.CreateComment(comment);
        return id;
    }
    public async Task<bool> Delete(DeleteComment deleteComment)
    {
        CommentEntity? comment = await commentRepository.GetEntityById(deleteComment.Id);
        if (comment == null) return false;
        await commentRepository.DeleteComment(comment);
        return true;
    }
    public async Task<bool> Update(PutComment putComment)
    {
        CommentEntity? comment = await commentRepository.GetEntityById(putComment.Id!.Value);
        if (comment == null) return false;
        comment.Update(putComment);
        await commentRepository.UpdateComment(comment);
        return true;
    }
    public async Task<GetComment?> GetById(int id)
    {
        CommentEntity? comment = await commentRepository.GetEntityById(id);
        if (comment == null) return null;
        return comment.ToDTO();
    }
    public async Task<List<GetComment>> GetAll()
    {
        List<CommentEntity> comments = await commentRepository.GetAllComments();
        List<GetComment> dtos = new List<GetComment>();
        foreach (CommentEntity comment in comments)
        {
            dtos.Add(comment.ToDTO());
        }
        return dtos;
    }
    public async Task<List<GetComment>> GetByDefectId(int defectId)
    {
        List<CommentEntity> comments = await commentRepository.GetCommentsByDefect(defectId);
        List<GetComment> dtos = new List<GetComment>();
        foreach (CommentEntity comment in comments)
        {
            dtos.Add(comment.ToDTO());
        }
        return dtos;
    }
}