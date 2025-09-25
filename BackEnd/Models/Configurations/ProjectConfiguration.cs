using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.projectEmployersEntities)
            .WithOne(pe => pe.projectEntity);

        builder.HasMany(p => p.reportEntities)
            .WithOne(r => r.projectEntity);
    }
}