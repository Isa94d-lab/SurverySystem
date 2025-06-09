using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.ToTable("questions");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(q => q.Chapter_id).HasColumnName("chapter_id");

            builder.Property(q => q.Created_at)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(q => q.Updated_at)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(q => q.Question_number).HasColumnName("question_number");
            builder.Property(q => q.Response_type).HasColumnName("response_type");
            builder.Property(q => q.Comment_question).HasColumnName("comment_question");
            builder.Property(q => q.Question_text).HasColumnName("question_text");

            builder.HasOne(q => q.Chapters)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.Chapter_id);

            builder.HasMany(q => q.Sub_Questions)
                .WithOne()
                .HasForeignKey("Question_id");
        }
    }
}
