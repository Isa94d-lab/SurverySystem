using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class Categories_catalogConfiguration : IEntityTypeConfiguration<Categories_catalog>
    {
        public void Configure(EntityTypeBuilder<Categories_catalog> builder)
        {
            builder.ToTable("categories_catalog");

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

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(255);

            // Relaciones
            builder.HasMany(c => c.Category_options)
                .WithOne(co => co.Categories_Catalog)
                .HasForeignKey(co => co.Catalogoptions_id);

            builder.HasMany(c => c.Option_questions)
                .WithOne(oq => oq.Categories_catalog)
                .HasForeignKey(oq => oq.Optioncatalog_id);
        }
    }
}
