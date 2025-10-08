namespace BackEnd.DTOs;

public record PutProfile
{
    public string?Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Email { get; set; }
}