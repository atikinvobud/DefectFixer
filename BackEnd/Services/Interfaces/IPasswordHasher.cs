namespace BackEnd.Services;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string hashPassword, string inputPassword);
}