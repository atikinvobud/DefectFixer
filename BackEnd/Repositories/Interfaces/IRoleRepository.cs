using BackEnd.DTOs;
using BackEnd.Models.Entities;
using StackExchange.Redis;

namespace BackEnd.Repositories;

public interface IRoleRepository
{
    Task<List<RoleEntity>> GetAllRoles();
    Task<RoleEntity?> GetEntityById(int id);
    Task<int> CreateRole(RoleEntity role);
    Task UpdateRole(RoleEntity role);
    Task DeleteRole(RoleEntity role);
}