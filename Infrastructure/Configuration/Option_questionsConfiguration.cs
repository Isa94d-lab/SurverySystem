using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class Option_questionsConfiguration : IEntityTypeConfiguration<Option_questions>
    {
        public void Configure(EntityTypeBuilder<Option_questions> builder)
        {
            builder.ToTable("option_questions");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(o => o.Created_at)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(o => o.Updated_at)
                   .HasColumnName("updated_at")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(o => o.Option_id)
                   .HasColumnName("option_id")
                   .IsRequired();

            builder.Property(o => o.Optioncatalog_id)
                   .HasColumnName("optioncatalog_id")
                   .IsRequired();

            builder.Property(o => o.Optionquestions_id)
                   .HasColumnName("optionquestions_id");

            builder.Property(o => o.Subquestion_id)
                   .HasColumnName("subquestion_id")
                   .IsRequired();

            builder.Property(o => o.Comment_optionres)
                   .HasColumnName("comment_optionres")
                   .HasMaxLength(500);

            builder.Property(o => o.Numberoption)
                   .HasColumnName("numberoption")
                   .HasMaxLength(50);

            builder.HasOne(o => o.Options_response)
                   .WithMany()
                   .HasForeignKey(o => o.Option_id);

            builder.HasOne(o => o.Categories_catalog)
                   .WithMany()
                   .HasForeignKey(o => o.Optioncatalog_id);

            builder.HasOne(o => o.Questions)
                   .WithMany()
                   .HasForeignKey(o => o.Optionquestions_id)
                   .OnDelete(DeleteBehavior.Restrict); // Evita ciclos

            builder.HasOne(o => o.Sub_questions)
                   .WithMany()
                   .HasForeignKey(o => o.Subquestion_id);

            builder.HasMany(o => o.Inverse_option_questions)
                   .WithOne(o => o.Parent_option_question)
                   .HasForeignKey(o => o.Optionquestions_id);
        }
    }
}
