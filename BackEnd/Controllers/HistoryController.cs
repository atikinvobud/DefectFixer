using System.Reflection.Metadata.Ecma335;
using BackEnd.DTOs;
using BackEnd.Models.Entities;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace  BackEnd.Controllers;

[ApiController]
[Route("history")]
public class HistoryController : ControllerBase
{
    private readonly IHistoryService historyService;
    public HistoryController(IHistoryService historyService)
    {
        this.historyService = historyService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await historyService.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetHistory? history = await historyService.GetById(id);
        if (history == null) return NotFound();
        return Ok(history);
    }
    [HttpGet("get/{defectId}")]
    public async Task<IActionResult> getByDefectId([FromRoute] int defectId)
    {
        return Ok(await historyService.GetByDefectId(defectId));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostHistory postHistory)
    {
        return Ok(await historyService.Create(postHistory));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] PutHistory putHistory)
    {
        bool success = await historyService.Update(putHistory);
        if (!success) return NotFound();
        return Ok();
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteHistory deleteHistory)
    {
        bool success = await historyService.Delete(deleteHistory);
        if (!success) return NotFound();
        return Ok();
    }
}