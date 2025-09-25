using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BackEnd.Models.Configurations;

public class HistoryConfiguration : IEntityTypeConfiguration<HistoryEntity>
{
    public void Configure(EntityTypeBuilder<HistoryEntity> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(h => h.statusEntity)
            .WithMany(s => s.historyEntities)
            .HasForeignKey(h => h.NewStatusId);

        builder.HasOne(h => h.defectEntity)
            .WithMany(d => d.historyEntities)
            .HasForeignKey(h => h.DefectId);

        builder.HasOne(h => h.userEntity)
            .WithMany(u => u.historyEntities)
            .HasForeignKey(h => h.UserId);
    }
}