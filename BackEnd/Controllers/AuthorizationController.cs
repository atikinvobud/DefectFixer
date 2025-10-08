using BackEnd.DTOs;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("auth")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationService authorizationService;
    public AuthorizationController(IAuthorizationService authorizationService)
    {
        this.authorizationService = authorizationService;
    }

 
    [HttpPost("registr")]
    public async Task<IActionResult> Registr([FromBody] RegistrDTO registrDTO)
    {
        AnswerRegistr answerRegistr = await authorizationService.RegistrUser(registrDTO);
        if (answerRegistr.UserId == 0) return Conflict(answerRegistr);
        return Ok(answerRegistr);
    }

    [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
{
    AnswerLoginDTO answerLogin = await authorizationService.Login(loginDTO);
    if (answerLogin.UserId == 0) return NotFound(answerLogin);

    Response.Cookies.Append(answerLogin.CoockieName, answerLogin.Token, new CookieOptions
    {
        HttpOnly = true,
        Secure = false, // локальная разработка
        SameSite = SameSiteMode.Lax, // для фронта на другом домене
        Expires = DateTime.UtcNow.AddHours(answerLogin.ExpireHours)
    });

    return Ok(answerLogin);
}


    [HttpPost("logout")]
    public IActionResult Logout([FromServices] IJwtService jwtService)
    {
        Response.Cookies.Delete(jwtService.GetCoockieName());
        return Ok();
    }
}