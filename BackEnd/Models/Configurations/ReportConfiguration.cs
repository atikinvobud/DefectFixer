using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<ReportEntity>
{
    public void Configure(EntityTypeBuilder<ReportEntity> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.projectEntity)
            .WithMany(p => p.reportEntities)
            .HasForeignKey(r => r.ProjectId);
    }
}