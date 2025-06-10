using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class Options_responseConfiguration : IEntityTypeConfiguration<Options_response>
    {
        public void Configure(EntityTypeBuilder<Options_response> builder)
        {
            builder.ToTable("options_response");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                   .HasColumnName("id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(o => o.Created_at)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(o => o.Updated_at)
                   .HasColumnName("updated_at")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(o => o.Optiontext)
                   .HasColumnName("optiontext");
        }
    }
}
