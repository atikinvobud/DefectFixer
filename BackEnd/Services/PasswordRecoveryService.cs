using BackEnd.Models;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class PasswordRecoveryService : IPasswordRecoveryService
{
    private readonly IRecoveryCodeRepository repository;
    private readonly IEmailService emailService;
    private readonly IAuthorizationService authorizationService;
    public PasswordRecoveryService(IRecoveryCodeRepository repository, IEmailService emailService, IAuthorizationService authorizationService)
    {
        this.repository = repository;
        this.emailService = emailService;
        this.authorizationService = authorizationService;
    }
    public async Task<string> GenerateRecoveryCodeAsync(string email)
    {
        var code = new Random().Next(100000, 999999).ToString();
        var recoveryData = new RecoveryData
        {
            Code = code,
            Email = email,
            CreatedAt = DateTime.UtcNow,
            IsUsed = false
        };
        await repository.SaveRecoveryCodeAsync(email, code, recoveryData, TimeSpan.FromMinutes(15));
        await repository.AddToRecoverySetAsync(email, code, TimeSpan.FromMinutes(15));
        await emailService.SendRecoveryCodeAsync(email, code);       
        return code;
    }

    public async Task<bool> ValidateRecoveryCodeAsync(string email, string code)
    {
        var recoveryData = await repository.GetRecoveryCodeAsync(email, code);
        if (recoveryData == null) return false;
        var isValid = !recoveryData.IsUsed && 
                     recoveryData.CreatedAt > DateTime.UtcNow.AddMinutes(-15);
        return isValid;
    }

    public async Task<bool> MarkCodeAsUsedAsync(string email, string code)
    {
        var recoveryData = await repository.GetRecoveryCodeAsync(email, code);
        if (recoveryData == null || recoveryData.IsUsed)
            return false;
        recoveryData.IsUsed = true;
        recoveryData.UsedAt = DateTime.UtcNow;
        await repository.UpdateRecoveryCodeAsync(email, code, recoveryData, TimeSpan.FromMinutes(5));
        await repository.RemoveFromRecoverySetAsync(email, code);
        return true;
    }

    public async Task<string?> VerifyCodeAndGenerateTokenAsync(string email, string code)
    {
        var isValid = await ValidateRecoveryCodeAsync(email, code);
        if (!isValid) return null;
        await MarkCodeAsUsedAsync(email, code);
        var resetToken = Guid.NewGuid().ToString();
        await repository.SaveResetTokenAsync(resetToken, email, TimeSpan.FromMinutes(10));        
        return resetToken;
    }

    public async Task<bool> ResetPasswordAsync(string resetToken, string newPassword)
    {
        var email = await repository.GetEmailByResetTokenAsync(resetToken);
        if (string.IsNullOrEmpty(email)) return false;
        if ( !await authorizationService.ChangePassword(email, newPassword)) return false;
        await repository.DeleteResetTokenAsync(resetToken);
        return true;
    }
}