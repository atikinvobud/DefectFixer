namespace BackEnd.DTOs;

public record ChangeAnswer
{
    public bool IsSuccess { get; set; } = false;
    public string Error { get; set; } = "";
}