using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class ApplicationsExtensions
{
    public static GetPicture ToDTO(this AplicationsEntity entity, string base64)
    {
        return new GetPicture()
        {
            FileName = entity.FileName,
            ContentType = entity.ContentType,
            Base64 = base64
        };
    }
}