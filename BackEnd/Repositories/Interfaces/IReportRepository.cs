using BackEnd.Models.Entities;

namespace BackEnd.Repositories;

public interface IReportRepository
{
    Task<List<ReportEntity>> GetReportByproject(int projectId);
    Task<int> CreateReport(ReportEntity report);
}