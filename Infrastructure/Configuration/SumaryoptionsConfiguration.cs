using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SumaryoptionsConfiguration : IEntityTypeConfiguration<Sumaryoptions>
    {
        public void Configure(EntityTypeBuilder<Sumaryoptions> builder)
        {
            builder.ToTable("sumaryoptions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id");

            builder.Property(e => e.Id_survey)
                   .HasColumnName("id_survey");

            builder.Property(e => e.Code_number)
                   .HasColumnName("code_number")
                   .HasMaxLength(50);

            builder.Property(e => e.Idquestion)
                   .HasColumnName("idquestion");

            builder.Property(e => e.Valuerta)
                   .HasColumnName("valuerta")
                   .HasMaxLength(255);

            builder.HasOne(e => e.Surveys)
                   .WithMany()
                   .HasForeignKey(e => e.Id_survey);
        }
    }
}
