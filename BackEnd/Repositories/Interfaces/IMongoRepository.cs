using MongoDB.Bson;

namespace BackEnd.Repositories;
public interface IMongoRepository
{
    Task<ObjectId> UploadPictureAsync(string fileName, Stream stream, string contentType);
    Task<ObjectId> UploadReportAsync(string fileName, Stream stream, string contentType);
    Task<(byte[] Data, string FileName, string ContentType)?> DownloadReportAsync(string id);
    Task<string?> GetPictureBase64Async(string id);
}