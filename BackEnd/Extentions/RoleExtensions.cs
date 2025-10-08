using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class RoleExtensions
{
    public static GetRole ToDTO(this RoleEntity role)
    {
        return new GetRole()
        {
            Id = role.Id,
            Name = role.Name
        };
    }
    public static RoleEntity ToEntity(this PostRole postRole)
    {
        return new RoleEntity()
        {
            Name = postRole.Name
        };
    }
    public static void Update(this RoleEntity entity, PutRole putRole)
    {
        entity.Name = putRole.Name;
    }
}