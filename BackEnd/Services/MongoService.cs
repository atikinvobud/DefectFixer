using BackEnd.Repositories;

namespace BackEnd.Services;
public class MongoService : IMongoService
{
    private readonly IMongoRepository mongoRepository;

    public MongoService(IMongoRepository mongoRepository)
    {
        this.mongoRepository = mongoRepository;
    }

    public async Task<string> UploadPictureAsync(IFormFile file)
    {
        using var stream = file.OpenReadStream();
        var id = await mongoRepository.UploadPictureAsync(file.FileName, stream, file.ContentType);
        return id.ToString();
    }

    public async Task<string> UploadReportAsync(IFormFile file)
    {
        using var stream = file.OpenReadStream();
        var id = await mongoRepository.UploadReportAsync(file.FileName, stream, file.ContentType);
        return id.ToString();
    }

    public async Task<(byte[] Data, string FileName, string ContentType)?> DownloadReportAsync(string id)
    {
        return await mongoRepository.DownloadReportAsync(id);
    }

    public async Task<string?> GetPictureBase64Async(string id)
    {
        return await mongoRepository.GetPictureBase64Async(id);
    }
}

