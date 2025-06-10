using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ChaptersConfiguration : IEntityTypeConfiguration<Chapters>
    {
        public void Configure(EntityTypeBuilder<Chapters> builder)
        {
            builder.ToTable("chapters");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Created_at)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.Updated_at)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.Survey_id)
                .HasColumnName("survey_id")
                .IsRequired();

            builder.Property(c => c.Componenthtml)
                .HasColumnName("componenthtml")
                .HasMaxLength(500);

            builder.Property(c => c.Componentreact)
                .HasColumnName("componentreact")
                .HasMaxLength(500);

            builder.Property(c => c.Chapter_number)
                .HasColumnName("chapter_number")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Chapter_title)
                .HasColumnName("chapter_title")
                .IsRequired()
                .HasMaxLength(255);

            // Relaciones
            builder.HasOne(c => c.Surveys)
                .WithMany(s => s.Chapters)
                .HasForeignKey(c => c.Survey_id);
        }
    }
}
