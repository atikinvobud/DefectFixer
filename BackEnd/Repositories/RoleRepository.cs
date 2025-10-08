using BackEnd.DTOs;
using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly Context context;
    public RoleRepository(Context context)
    {
        this.context = context;
    }

    public async Task<List<RoleEntity>> GetAllRoles()
    {
        return await context.Roles.ToListAsync();
    }
    public async Task<RoleEntity?> GetEntityById(int id)
    {
        return await context.Roles.FindAsync(id);
    }
    public async Task<int> CreateRole(RoleEntity role)
    {
        await context.Roles.AddAsync(role);
        await context.SaveChangesAsync();
        return role.Id;
    }
    public async Task UpdateRole(RoleEntity role)
    {
        context.Roles.Update(role);
        await context.SaveChangesAsync();
    }
    public async Task DeleteRole(RoleEntity role)
    {
        context.Roles.Remove(role);
        await context.SaveChangesAsync();
    }
}