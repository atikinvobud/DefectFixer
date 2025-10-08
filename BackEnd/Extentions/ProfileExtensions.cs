using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class ProfileExtensions
{
    public static GetProfile ToDTO(this UserInfoEntity userInfo)
    {
        return new GetProfile()
        {
            Name = userInfo.Name + " " + userInfo.Surname + " " + userInfo.Patronymic,
            RoleName = userInfo.user!.roleEntity!.Name,
            Email = userInfo.user!.Login
        };
    }

    public static void Update(this UserInfoEntity userInfo, PutProfile profile)
    {
        userInfo.Name = profile.Name ?? userInfo.Name;
        userInfo.Surname = profile.Surname ?? userInfo.Surname;
        userInfo.Patronymic = profile.Patronymic ?? userInfo.Patronymic;
        userInfo.user!.Login = profile.Email ?? userInfo.user!.Login;
    }
}