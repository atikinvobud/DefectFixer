namespace BackEnd.Models.Entities;

public class StatusEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<DefectEntity> defectEntities { get; set; } = new List<DefectEntity>();
    public List<HistoryEntity> historyEntities{ get; set; } = new List<HistoryEntity>();
}