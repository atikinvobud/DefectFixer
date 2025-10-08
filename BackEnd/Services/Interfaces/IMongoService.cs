namespace BackEnd.Services;
public interface IMongoService
{
    Task<string> UploadPictureAsync(IFormFile file);
    Task<string> UploadReportAsync(IFormFile file);
    Task<(byte[] Data, string FileName, string ContentType)?> DownloadReportAsync(string id);
    Task<string?> GetPictureBase64Async(string id);
}