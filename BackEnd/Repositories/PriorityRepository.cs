using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories;

public class PriorityRepository : IPriorityRepository
{
    private readonly Context context;
    public PriorityRepository(Context context)
    {
        this.context = context;
    }

    public async Task<List<PriorityEntity>> GetAllPriorities()
    {
        return await context.Priorities.ToListAsync();
    }
    public async Task<PriorityEntity?> GetEntityById(int id)
    {
        return await context.Priorities.FindAsync(id);
    }
    public async Task<int> CreatePriority(PriorityEntity priority)
    {
        await context.Priorities.AddAsync(priority);
        await context.SaveChangesAsync();
        return priority.Id;
    }
    public async Task UpdatePriority(PriorityEntity priority)
    {
        context.Priorities.Update(priority);
        await context.SaveChangesAsync();
    }
    public async Task DeletePriority(PriorityEntity priority)
    {
        context.Priorities.Remove(priority);
        await context.SaveChangesAsync();
    }
}