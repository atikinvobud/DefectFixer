using BackEnd.DTOs;

namespace BackEnd.Services;

public interface IReportService
{
    Task<int> DownloadReport(IFormFile formFile, int projectId);
    Task<List<GetReport>> GetReport(int projectId);
}