using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class PriorityConfiguration : IEntityTypeConfiguration<PriorityEntity>
{
    public void Configure(EntityTypeBuilder<PriorityEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.defectEntities)
            .WithOne(d => d.priorityEntity);
    }
}