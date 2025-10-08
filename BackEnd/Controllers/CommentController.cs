using System.Reflection.Metadata.Ecma335;
using BackEnd.DTOs;
using BackEnd.Models.Entities;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace  BackEnd.Controllers;

[ApiController]
[Route("comment")]
public class CommentController : ControllerBase
{
    private readonly ICommentService commentService;
    public CommentController(ICommentService commentService)
    {
        this.commentService = commentService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await commentService.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetComment? comment = await commentService.GetById(id);
        if (comment == null) return NotFound();
        return Ok(comment);
    }
    [HttpGet("get/{defectId}")]
    public async Task<IActionResult> getByDefectId([FromRoute] int defectId)
    {
        return Ok(await commentService.GetByDefectId(defectId));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostComment postComment)
    {
        return Ok(await commentService.Create(postComment));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] PutComment putComment)
    {
        bool success = await commentService.Update(putComment);
        if (!success) return NotFound();
        return Ok();
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteComment deleteComment)
    {
        bool success = await commentService.Delete(deleteComment);
        if (!success) return NotFound();
        return Ok();
    }
}