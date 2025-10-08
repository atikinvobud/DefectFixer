using System.Reflection.Metadata.Ecma335;
using BCrypt;
namespace BackEnd.Services;

public class PasswordHasherService : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string HashPassword, string inputPassword)
    {
        return BCrypt.Net.BCrypt.Verify(inputPassword, HashPassword);
    }
}