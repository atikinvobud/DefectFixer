using BackEnd.DTOs;
using BackEnd.Models.Entities;

namespace BackEnd.Extentions;

public static class PriorityExtensions
{
    public static GetPriority ToDTO(this PriorityEntity priority)
    {
        return new GetPriority()
        {
            Id = priority.Id,
            Name = priority.Name
        };
    }
    public static PriorityEntity ToEntity(this PostPriority postPriority)
    {
        return new PriorityEntity()
        {
            Name = postPriority.Name
        };
    }
    public static void Update(this PriorityEntity entity, PutPriority putPriority)
    {
        entity.Name = putPriority.Name;
    }
}