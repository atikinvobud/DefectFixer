namespace BackEnd.DTOs;

public record GetPicture()
{
    public string FileName { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string Base64 { get; set; } = null!;
}