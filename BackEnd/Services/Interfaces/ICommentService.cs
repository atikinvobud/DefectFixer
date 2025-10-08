using BackEnd.DTOs;
using StackExchange.Redis;

namespace BackEnd.Services;

public interface ICommentService
{
    Task<int> Create(PostComment postComment);
    Task<bool> Delete(DeleteComment deleteComment);
    Task<List<GetComment>> GetAll();
    Task<List<GetComment>> GetByDefectId(int defectId);
    Task<GetComment?> GetById(int id);
    Task<bool> Update(PutComment putComment);
}