using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Models.Entities;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository reportRepository;
    private readonly IMongoRepository mongoRepository;

    public ReportService(IReportRepository reportRepository, IMongoRepository mongoRepository)
    {
        this.reportRepository = reportRepository;
        this.mongoRepository = mongoRepository;
    }

    public async Task<List<GetReport>> GetReport(int projectId)
    {
        List<ReportEntity> reports = await reportRepository.GetReportByproject(projectId);
        var result = new List<GetReport>();
        foreach (var report in reports)
        {
            var file = await mongoRepository.DownloadReportAsync(report.MongoDocumentId);
            if (file != null)
            {
                result.Add(new GetReport
                {
                    FileName = file.Value.FileName,
                    ContentType = file.Value.ContentType,
                    Data = file.Value.Data
                });
            }
        }
        return result;
    }
    public async Task<int> DownloadReport(IFormFile formFile, int projectId)
    {
        using var stream = formFile.OpenReadStream();
        var id = await mongoRepository.UploadReportAsync(formFile.FileName, stream, formFile.ContentType);
        var entity = new ReportEntity()
        {
            ProjectId = projectId,
            FileName = formFile.FileName,
            GeneratedAt = DateTime.UtcNow,
            ContentType = formFile.ContentType,
            MongoDocumentId =id.ToString()
        };
        int pgId = await reportRepository.CreateReport(entity);
        return pgId;
    }
}