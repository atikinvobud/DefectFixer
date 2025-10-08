using System.Reflection.Metadata.Ecma335;
using BackEnd.DTOs;
using BackEnd.Models.Entities;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace  BackEnd.Controllers;

[ApiController]
[Route("role")]
public class RoleController : ControllerBase
{
    private readonly IRoleService roleService;
    public RoleController(IRoleService roleService)
    {
        this.roleService = roleService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await roleService.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetRole? role = await roleService.GetById(id);
        if (role == null) return NotFound();
        return Ok(role);
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostRole postRole)
    {
        return Ok(await roleService.Create(postRole));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] PutRole putRole)
    {
        bool success = await roleService.Update(putRole);
        if (!success) return NotFound();
        return Ok();
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteRole deleteRole)
    {
        bool success = await roleService.Delete(deleteRole);
        if (!success) return NotFound();
        return Ok();
    }
}