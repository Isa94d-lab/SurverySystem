using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SurveysConfiguration : IEntityTypeConfiguration<Surveys>
    {
        public void Configure(EntityTypeBuilder<Surveys> builder)
        {
            builder.ToTable("surveys");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Created_at)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(s => s.Updated_at)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(s => s.Componentreact).HasColumnName("componentreact");
            builder.Property(s => s.Componenthtml).HasColumnName("componenthtml");
            builder.Property(s => s.Description).HasColumnName("description");
            builder.Property(s => s.Instruction).HasColumnName("instruction");
            builder.Property(s => s.Name).HasColumnName("name");

            // Relaciones
            builder.HasMany(s => s.Chapters)
                   .WithOne(c => c.Surveys)
                   .HasForeignKey(c => c.Survey_id);
        }
    }
}
