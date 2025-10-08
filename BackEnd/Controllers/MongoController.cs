using Microsoft.AspNetCore.Mvc;
using BackEnd.Services;
using System.Security.Claims;

[ApiController]
[Route("mongo")]
public class MongoController : ControllerBase
{
    private readonly IMongoService mongoService;
    private readonly IPictureService pictureService;

    public MongoController(IMongoService mongoService, IPictureService pictureService)
    {
        this.mongoService = mongoService;
        this.pictureService = pictureService;  
    }

    [HttpPost("upload-picture/{defectId}")]
    public async Task<IActionResult> UploadPicture(IFormFile file, [FromRoute] int defectId)
    {
        int userId = int.Parse(User.FindFirstValue("userId")!);
        var id = await pictureService.DownloadPictire(file,defectId,userId);
        return Ok(new { MongoPictureId = id });
    }

    [HttpPost("upload-report")]
    public async Task<IActionResult> UploadReport(IFormFile file)
    {
        var id = await mongoService.UploadReportAsync(file);
        return Ok(new { MongoDocumentId = id });
    }

    [HttpGet("download-report/{id}")]
    public async Task<IActionResult> DownloadReport(string id)
    {
        var result = await mongoService.DownloadReportAsync(id);
        if (result == null) return NotFound();
        return File(result.Value.Data, result.Value.ContentType, result.Value.FileName);
    }

    [HttpGet("get-picture/{defectId}")]
    public async Task<IActionResult> GetPicture([FromRoute] int defectId)
    {
        return Ok(await pictureService.GetPicture(defectId));
    }
}
