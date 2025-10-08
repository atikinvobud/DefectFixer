using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Models.Entities;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository roleRepository;
    public RoleService(IRoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    public async Task<int> Create(PostRole postRole)
    {
        RoleEntity role = postRole.ToEntity();
        int id = await roleRepository.CreateRole(role);
        return id;
    }
    public async Task<bool> Delete(DeleteRole deleteRole)
    {
        RoleEntity? role = await roleRepository.GetEntityById(deleteRole.Id);
        if (role == null) return false;
        await roleRepository.DeleteRole(role);
        return true;
    }
    public async Task<bool> Update(PutRole putRole)
    {
        RoleEntity? role = await roleRepository.GetEntityById(putRole.Id);
        if (role == null) return false;
        role.Update(putRole);
        await roleRepository.UpdateRole(role);
        return true;
    }
    public async Task<GetRole?> GetById(int id)
    {
        RoleEntity? role = await roleRepository.GetEntityById(id);
        if (role == null) return null;
        return role.ToDTO();
    }
    public async Task<List<GetRole>> GetAll()
    {
        List<RoleEntity> roles = await roleRepository.GetAllRoles();
        List<GetRole> dtos = new List<GetRole>();
        foreach (RoleEntity role in roles)
        {
            dtos.Add(role.ToDTO());
        }
        return dtos;
    }
}