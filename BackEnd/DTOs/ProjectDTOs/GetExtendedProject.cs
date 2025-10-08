namespace BackEnd.DTOs;

public record GetExtendedProject
{
    public int Id { get; set; }
    public int DefectAmount { get; set; }
    public int ActiveDefects { get; set; }
    public int CriticalDefects { get; set; }
    public string Name { get; set; } = null!;
    public List<string> ManagerNames { get; set; } = new List<string>();
}