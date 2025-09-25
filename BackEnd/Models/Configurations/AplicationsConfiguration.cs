using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Models.Configurations;

public class AplicationConfiguration : IEntityTypeConfiguration<AplicationsEntity>
{
    public void Configure(EntityTypeBuilder<AplicationsEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.defect)
            .WithMany(d => d.aplicationsEntities)
            .HasForeignKey(a => a.DefectId);

        builder.HasOne(a => a.user)
            .WithMany(u => u.aplicationsEntities)
            .HasForeignKey(a => a.UploadedById);
            
    }
}