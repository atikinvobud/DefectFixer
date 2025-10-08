using System.Reflection.Metadata.Ecma335;
using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class UserInfoExtentions
{
    public static UserInfoEntity ToInfoEntity(this RegistrDTO registrDTO, int userId)
    {
        return new UserInfoEntity()
        {
            Id =userId,
            Name = registrDTO.Name,
            Surname = registrDTO.Surname,
            Patronymic = registrDTO.Patronymic
        };
    }
}