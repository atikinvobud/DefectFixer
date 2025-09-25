using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class ProjectEmployersConfiguration : IEntityTypeConfiguration<ProjectEmployersEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEmployersEntity> builder)
    {
        builder.HasKey(pe => pe.Id);

        builder.HasOne(pe => pe.projectEntity)
            .WithMany(p => p.projectEmployersEntities)
            .HasForeignKey(pe => pe.ProjectId);

        builder.HasOne(pe => pe.userEntity)
            .WithMany(u => u.projectEmployersEntities)
            .HasForeignKey(pe => pe.UserId);
    }
}