using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Models.Entities;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class PictureService : IPictureService
{
    private readonly IApplicationRepository applicationRepository;
    private readonly IMongoRepository mongoRepository;

    public PictureService(IApplicationRepository applicationRepository, IMongoRepository mongoRepository)
    {
        this.applicationRepository = applicationRepository;
        this.mongoRepository = mongoRepository;
    }

    public async Task<List<GetPicture>> GetPicture(int defectId)
    {
        List<AplicationsEntity> applications = await applicationRepository.GetPhotoByDefect(defectId);
        var result = new List<GetPicture>();
        foreach (var aplication in applications)
        {
            var base64 = await mongoRepository.GetPictureBase64Async(aplication.MongoPictureId);
            if (base64 == null) continue;
            result.Add(aplication.ToDTO(base64));
        }
        return result;
    }
    public async Task<int> DownloadPictire(IFormFile formFile, int defectId, int userId)
    {
        using var stream = formFile.OpenReadStream();
        var id = await mongoRepository.UploadPictureAsync(formFile.FileName, stream, formFile.ContentType);
        var entity = new AplicationsEntity()
        {
            DefectId = defectId,
            UploadedById = userId,
            FileName = formFile.FileName,
            UploadedAt = DateTime.UtcNow,
            MongoPictureId = id.ToString(),
            ContentType = formFile.ContentType
        };
        int pgId = await applicationRepository.CretePhato(entity);
        return pgId;
    }
}