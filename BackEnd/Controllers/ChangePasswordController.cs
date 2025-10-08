using System.Security.Claims;
using BackEnd.DTOs;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("change-password")]
public class ChangePasswordController : ControllerBase
{
    private readonly IChangePasswordService changePasswordservice;
    public ChangePasswordController(IChangePasswordService changePasswordService)
    {
        this.changePasswordservice = changePasswordService;
    }

    [HttpPut("")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePassword changePassword)
    {
        int userId = int.Parse(User.FindFirstValue("userId")!);
        ChangeAnswer answer = await changePasswordservice.ChangePassword(changePassword, userId);
        return Ok(answer);
    }
}