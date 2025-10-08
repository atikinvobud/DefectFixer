using BackEnd.Models.Entities;

namespace BackEnd.Repositories;

public interface IProfileRepository
{
    Task<UserInfoEntity?> GetProfile(int userId);
    Task UpdateProfile();
}