using BackEnd.DTOs;

namespace BackEnd.Services;

public interface IProfileService
{
    Task<GetProfile?> GetProfileInfo(int userId);
    Task<bool> UpdateProfile(PutProfile profile, int userId);
}