using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class Category_optionsConfiguration : IEntityTypeConfiguration<Category_options>
    {
        public void Configure(EntityTypeBuilder<Category_options> builder)
        {
            builder.ToTable("category_options");

            builder.HasKey(co => co.Id);

            builder.Property(co => co.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(co => co.Catalogoptions_id)
                .HasColumnName("catalogoptions_id")
                .IsRequired();

            builder.Property(co => co.Categoriesoptions_id)
                .HasColumnName("categoriesoptions_id")
                .IsRequired();

            builder.Property(co => co.Created_at)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(co => co.Updated_at)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relaciones
            builder.HasOne(co => co.Categories_Catalog)
                .WithMany(cc => cc.Category_options)
                .HasForeignKey(co => co.Catalogoptions_id);

            builder.HasOne(co => co.Options_Response)
                .WithMany(or => or.Category_options)
                .HasForeignKey(co => co.Categoriesoptions_id);
        }
    }
}
