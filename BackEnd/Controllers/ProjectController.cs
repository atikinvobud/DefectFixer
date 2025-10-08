using System.Runtime.CompilerServices;
using System.Security.Claims;
using BackEnd.DTOs;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("project")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService projectService;
    public ProjectController(IProjectService projectService)
    {
        this.projectService = projectService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostProject postProject)
    {
        return Ok(await projectService.Create(postProject));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] PutProject putProject)
    {
        bool success = await projectService.Update(putProject);
        if (!success) return NotFound();
        return Ok();
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteProject deleteProject)
    {
        bool success = await projectService.Delete(deleteProject);
        if (!success) return NotFound();
        return Ok();
    }
    [HttpPost("apply-user")]
    public async Task<IActionResult> AppointUser([FromBody] AddUser addUser)
    {
        return Ok(await projectService.ApplyUser(addUser));
    }
    [HttpGet("baseproject")]
    public async Task<IActionResult> GetBaseProject()
    {
        int userId = int.Parse(User.FindFirstValue("userId")!);
        return Ok(await projectService.GetAllBase(userId));
    }
    [HttpGet("extendedproject")]
    public async Task<IActionResult> GetExtendedProject()
    {
        int userId = int.Parse(User.FindFirstValue("userId")!);
        return Ok(await projectService.GetAllExtended(userId));
    }
}