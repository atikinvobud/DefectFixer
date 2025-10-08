using BackEnd.DTOs;

namespace BackEnd.Services;

public interface IChangePasswordService
{
    Task<ChangeAnswer> ChangePassword(ChangePassword changePassword, int userId);
}