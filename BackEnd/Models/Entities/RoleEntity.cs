namespace BackEnd.Models.Entities;

public class RoleEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<UserEntity> Users{ get; set; } = new List<UserEntity>();
}