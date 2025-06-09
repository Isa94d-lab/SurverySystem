using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class Sub_questionsConfiguration : IEntityTypeConfiguration<Sub_questions>
    {
        public void Configure(EntityTypeBuilder<Sub_questions> builder)
        {
            builder.ToTable("sub_questions");

            builder.HasKey(sq => sq.Id);

            builder.Property(sq => sq.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(sq => sq.Created_at)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(sq => sq.Updated_at)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(sq => sq.Questions_id)
                .HasColumnName("questions_id")
                .IsRequired();

            builder.Property(sq => sq.Subquestion_number)
                .HasColumnName("subquestion_number")
                .HasMaxLength(50);

            builder.Property(sq => sq.Comment_subquestion)
                .HasColumnName("comment_subquestion")
                .HasMaxLength(500);

            builder.Property(sq => sq.Subquestiontext)
                .HasColumnName("subquestiontext")
                .HasMaxLength(1000);

            // Relaciones
            builder.HasOne(sq => sq.Questions)
                .WithMany(q => q.Sub_questions)
                .HasForeignKey(sq => sq.Questions_id);
        }
    }
}
