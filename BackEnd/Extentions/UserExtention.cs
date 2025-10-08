using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class UserExtentions
{
    public static UserEntity ToEntity(this RegistrDTO registrDTO)
    {
        return new UserEntity()
        {
            Login = registrDTO.Login,
            HashPassword = registrDTO.Password,
            RoleId = registrDTO.RoleId
        };
    }
    public static void UpdatePassword(this UserEntity entity, ChangePassword changePassword)
    {
        entity.HashPassword = changePassword.NewPassword;
    }
}