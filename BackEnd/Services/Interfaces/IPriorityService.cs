using BackEnd.DTOs;
namespace BackEnd.Services;

public interface IPriorityService
{
    Task<int> Create(PostPriority postPriority);
    Task<bool> Delete(DeletePriority deletePriority);
    Task<List<GetPriority>> GetAll();
    Task<GetPriority?> GetById(int id);
    Task<bool> Update(PutPriority putPriority);
}