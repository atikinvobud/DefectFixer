using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasMany(s => s.defectEntities)
            .WithOne(d => d.statusEntity);
    }
}