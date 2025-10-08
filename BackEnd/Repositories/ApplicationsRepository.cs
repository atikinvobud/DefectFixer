using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories;

public class ApplicationsRepository : IApplicationRepository
{
    private readonly Context context;
    public ApplicationsRepository(Context context)
    {
        this.context = context;
    }
    public async Task<List<AplicationsEntity>> GetPhotoByDefect(int defectId)
    {
        return await context.Applications.Where(a => a.DefectId == defectId).ToListAsync();
    }
    public async Task<int> CretePhato(AplicationsEntity aplicationsEntity)
    {
        await context.Applications.AddAsync(aplicationsEntity);
        await context.SaveChangesAsync();
        return aplicationsEntity.Id;
    }
}