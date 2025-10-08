using BackEnd.Models.Entities;

namespace BackEnd.Repositories;

public interface IUserRepository
{
    Task<int> CreateUser(UserEntity userEntity);
    Task CreateUserInfo(UserInfoEntity userInfoEntity);
    Task<UserEntity?> GetUserById(int userId);
    Task<List<UserEntity>> GetAllUsers();
    Task<UserEntity?> GetUserByLogin(string login);
    Task UpdateUser(UserEntity user, string newPassword);
    Task Update();
}