using BackEnd.DTOs;

namespace BackEnd.Services;

public interface IEmailService
{
    Task SendRecoveryCodeAsync(string email, string code);
    Task SendEmailAsync(SendEmailDTO sendEmailDTO);
}