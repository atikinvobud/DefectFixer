using System.Security.Claims;
using BackEnd.DTOs;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("profile")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService profileService;
    public ProfileController(IProfileService profileService)
    {
        this.profileService = profileService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetProfile()
    {
        int userId = int.Parse(User.FindFirstValue("userId")!);
        var user = await profileService.GetProfileInfo(userId);
        if (user == null) return NotFound();
        return Ok(user);
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateProfile([FromBody] PutProfile putProfile)
    {
        int userId = int.Parse(User.FindFirstValue("userId")!);
        bool success = await profileService.UpdateProfile(putProfile, userId);
        if (!success) return NotFound();
        return Ok();
    }

}