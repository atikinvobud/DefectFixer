using BackEnd.Models;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly Context context;
    public ReportRepository(Context context)
    {
        this.context = context;
    }
    public async Task<List<ReportEntity>> GetReportByproject(int projectId)
    {
        return await context.Reports.Where(r => r.ProjectId == projectId).ToListAsync();
    }
    public async Task<int> CreateReport(ReportEntity report)
    {
        await context.Reports.AddAsync(report);
        await context.SaveChangesAsync();
        return report.Id;
    }
}