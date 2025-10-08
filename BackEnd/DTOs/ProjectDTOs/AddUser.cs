namespace BackEnd.DTOs;

public record AddUser
{
    public int UserId { get; set; }
    public int ProjectId { get; set; }
}