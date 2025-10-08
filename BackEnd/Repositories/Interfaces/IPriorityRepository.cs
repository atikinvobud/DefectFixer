using BackEnd.DTOs;
using BackEnd.Models.Entities;
using StackExchange.Redis;

namespace BackEnd.Repositories;

public interface IPriorityRepository
{
    Task<List<PriorityEntity>> GetAllPriorities();
    Task<PriorityEntity?> GetEntityById(int id);
    Task<int> CreatePriority(PriorityEntity priority);
    Task UpdatePriority(PriorityEntity priority);
    Task DeletePriority(PriorityEntity priority);
}