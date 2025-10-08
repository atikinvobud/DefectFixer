using BackEnd.DTOs;
using StackExchange.Redis;

namespace BackEnd.Services;

public interface IHistoryService
{
    Task<int> Create(PostHistory postHistory);
    Task<bool> Delete(DeleteHistory deleteHistory);
    Task<List<GetHistory>> GetAll();
    Task<List<GetHistory>> GetByDefectId(int defectId);
    Task<GetHistory?> GetById(int id);
    Task<bool> Update(PutHistory putHistory);
}