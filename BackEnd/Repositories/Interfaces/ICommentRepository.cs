using BackEnd.DTOs;
using BackEnd.Models.Entities;
using StackExchange.Redis;

namespace BackEnd.Repositories;

public interface ICommentRepository
{
    Task<List<CommentEntity>> GetAllComments();
    Task<List<CommentEntity>> GetCommentsByDefect(int defectId);
    Task<CommentEntity?> GetEntityById(int id);
    Task<int> CreateComment(CommentEntity comment);
    Task UpdateComment(CommentEntity comment);
    Task DeleteComment(CommentEntity comment);
}