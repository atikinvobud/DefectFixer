using System.Reflection.Metadata.Ecma335;
using BackEnd.DTOs;
using BackEnd.Models.Entities;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace  BackEnd.Controllers;

[ApiController]
[Route("priority")]
public class PriorityController : ControllerBase
{
    private readonly IPriorityService priorityService;
    public PriorityController(IPriorityService priorityService)
    {
        this.priorityService = priorityService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await priorityService.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetPriority? priority = await priorityService.GetById(id);
        if (priority == null) return NotFound();
        return Ok(priority);
    }
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostPriority postPriority)
    {
        return Ok(await priorityService.Create(postPriority));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] PutPriority putPriority)
    {
        bool success = await priorityService.Update(putPriority);
        if (!success) return NotFound();
        return Ok();
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeletePriority deletePriority)
    {
        bool success = await priorityService.Delete(deletePriority);
        if (!success) return NotFound();
        return Ok();
    }
}