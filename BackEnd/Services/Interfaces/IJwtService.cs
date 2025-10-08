using BackEnd.Models.Entities;

namespace BackEnd.Services;

public interface IJwtService
{
    string GenerateToken(UserEntity user);
    string GetCoockieName();
    int GetExpireHours();
}