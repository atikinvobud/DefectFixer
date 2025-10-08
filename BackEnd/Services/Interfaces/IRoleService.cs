
using BackEnd.DTOs;
using StackExchange.Redis;

namespace BackEnd.Services;

public interface IRoleService
{
    Task<int> Create(PostRole postRole);
    Task<bool> Delete(DeleteRole deleteRole);
    Task<List<GetRole>> GetAll();
    Task<GetRole?> GetById(int id);
    Task<bool> Update(PutRole putRole);
}