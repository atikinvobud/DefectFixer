namespace BackEnd.Services;

public interface IPasswordRecoveryService
{
    Task<string> GenerateRecoveryCodeAsync(string email);
    Task<bool> ValidateRecoveryCodeAsync(string email, string code);
    Task<bool> MarkCodeAsUsedAsync(string email, string code);
    Task<string?> VerifyCodeAndGenerateTokenAsync(string email, string code);
    Task<bool> ResetPasswordAsync(string resetToken, string newPassword);
}