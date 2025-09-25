using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class DefectConfiguration : IEntityTypeConfiguration<DefectEntity>
{
    public void Configure(EntityTypeBuilder<DefectEntity> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.statusEntity)
            .WithMany(s => s.defectEntities)
            .HasForeignKey(d => d.StatusId);

        builder.HasOne(d => d.priorityEntity)
            .WithMany(p => p.defectEntities)
            .HasForeignKey(d => d.PriorityId);

        builder.HasOne(d => d.projectEntity)
            .WithMany(p => p.defectEntities)
            .HasForeignKey(d => d.ProjectId);

        builder.HasOne(d => d.author)
            .WithMany(u => u.AuthorDefects)
            .HasForeignKey(d => d.AuthorId);

        builder.HasOne(d => d.engeneer)
            .WithMany(u => u.ExecutorDefects)
            .HasForeignKey(d => d.CurrentEngeneerId);

        builder.HasMany(d => d.aplicationsEntities)
            .WithOne(a => a.defect);

        builder.HasMany(d => d.commentEntities)
            .WithOne(c => c.defectEntity);

        builder.HasMany(d => d.historyEntities)
            .WithOne(h => h.defectEntity);
    }
}