namespace BackEnd.Models.Entities;

public class PriorityEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<DefectEntity> defectEntities { get; set; } = new List<DefectEntity>();
}