namespace BackEnd.Models.Entities;

public class ReportEntity
{
    public int Id { get; set; }
    public required int ProjectId { get; set; }
    public required string Title { get; set; }
    public required DateTime GeneratedAt { get; set; }
    public required string MongoDocumentId { get; set; }
    public ProjectEntity? projectEntity { get; set; }
}