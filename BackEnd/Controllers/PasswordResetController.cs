using BackEnd.DTOs;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("reset")]
public class PasswordRecoveryController : ControllerBase
{
    private readonly IPasswordRecoveryService recoveryService;

    public PasswordRecoveryController(IPasswordRecoveryService recoveryService)
    {
        this.recoveryService = recoveryService;
    }

    [HttpPost("request")]
    public async Task<IActionResult> RequestRecovery([FromBody] RequestRecoveryDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Email)) return BadRequest(new { message = "Email обязателен" });
        await recoveryService.GenerateRecoveryCodeAsync(request.Email);
        return Ok(new { message = "Код восстановления отправлен на email" });
    }

    [HttpPost("verify")]
    public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Code)) return BadRequest(new { message = "Email и код обязательны" });
        var resetToken = await recoveryService.VerifyCodeAndGenerateTokenAsync(request.Email, request.Code);
        if (resetToken == null) return BadRequest(new { message = "Неверный или просроченный код" });
        return Ok(new { resetToken = resetToken });
    }

    [HttpPost("reset")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
    {
        if (string.IsNullOrWhiteSpace(request.ResetToken) || string.IsNullOrWhiteSpace(request.NewPassword))return BadRequest(new { message = "Токен и новый пароль обязательны" });
        var success = await recoveryService.ResetPasswordAsync(request.ResetToken, request.NewPassword);
        if (!success) return BadRequest(new { message = "Неверный или просроченный токен" });
        return Ok(new { message = "Пароль успешно изменен" });
    }
}