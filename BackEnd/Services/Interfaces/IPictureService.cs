using BackEnd.DTOs;

namespace BackEnd.Services;

public interface IPictureService
{
    Task<int> DownloadPictire(IFormFile formFile, int defectId, int userId);
    Task<List<GetPicture>> GetPicture(int DefectId);
}