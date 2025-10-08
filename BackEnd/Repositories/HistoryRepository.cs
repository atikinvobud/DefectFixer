using BackEnd.DTOs;
using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly Context context;
    public HistoryRepository(Context context)
    {
        this.context = context;
    }

    public async Task<List<HistoryEntity>> GetAllHistory()
    {
        return await context.Histories.Include(h => h.userEntity).ThenInclude(u => u!.UserInfoEntity).Include(h => h.statusEntity).ToListAsync();
    }
    public async Task<List<HistoryEntity>> GetHistoryByDefect(int defectId)
    {
        return await context.Histories.Where(h => h.DefectId == defectId).Include(h => h.userEntity)
                .ThenInclude(u => u!.UserInfoEntity).Include(h => h.statusEntity).ToListAsync();
    }
    public async Task<HistoryEntity?> GetEntityById(int id)
    {
        return await context.Histories.Include(h => h.userEntity).ThenInclude(u => u!.UserInfoEntity).Include(h => h.statusEntity).FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<int> CreateHistory(HistoryEntity history)
    {
        await context.Histories.AddAsync(history);
        await context.SaveChangesAsync();
        return history.Id;
    }
    public async Task UpdateHistory(HistoryEntity history)
    {
            context.Histories.Update(history);
            await context.SaveChangesAsync();
    }
    public async Task DeleteHistory(HistoryEntity history)
    {
        context.Histories.Remove(history);
        await context.SaveChangesAsync();
    }
}