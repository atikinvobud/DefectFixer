namespace BackEnd.Models.Entities;

public class DefectEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required int StatusId { get; set; }
    public required int PriorityId { get; set; }
    public required DateTime DeadlinaDate { get; set; }
    public required int ProjectId { get; set; }
    public required int AuthorId { get; set; }
    public required int CurrentEngeneerId { get; set; }
    public StatusEntity? statusEntity { get; set; }
    public PriorityEntity? priorityEntity { get; set; }
    public ProjectEntity? projectEntity { get; set; }
    public UserEntity? author { get; set; }
    public UserEntity? engeneer { get; set; }
    public List<AplicationsEntity> aplicationsEntities { get; set; } = new List<AplicationsEntity>();
    public List<CommentEntity> commentEntities { get; set; } = new List<CommentEntity>();
    public List<HistoryEntity> historyEntities { get; set; } = new List<HistoryEntity>();
    
}