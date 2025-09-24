namespace BackEnd.Models.Entities;

public class UserInfoEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Patronymic { get; set; }
    public UserEntity? user { get; set; }
}