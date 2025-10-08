using MongoDB.Driver;

namespace BackEnd.Models.Entities;

public class ReportEntity
{
    public int Id { get; set; }
    public required int ProjectId { get; set; }
    public required string FileName { get; set; }
    public required string ContentType { get; set; }
    public required DateTime GeneratedAt { get; set; }
    public required string MongoDocumentId { get; set; }
    public ProjectEntity? projectEntity { get; set; }
}