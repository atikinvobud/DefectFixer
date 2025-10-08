using BackEnd.DTOs;
using BackEnd.Models.Entities;
using StackExchange.Redis;

namespace BackEnd.Repositories;

public interface IHistoryRepository
{
    Task<List<HistoryEntity>> GetAllHistory();
    Task<List<HistoryEntity>> GetHistoryByDefect(int defectId);
    Task<HistoryEntity?> GetEntityById(int id);
    Task<int> CreateHistory(HistoryEntity history);
    Task UpdateHistory(HistoryEntity history);
    Task DeleteHistory(HistoryEntity history);
}