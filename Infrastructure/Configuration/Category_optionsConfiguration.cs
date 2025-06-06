using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Configuration
{
    public class Category_optionsConfiguration : IEntityTypeConfiguration<Category_options>
    {
        public void Configure(EntityTypeBuilder<Category_options> builder)
        {
            builder.ToTable("category_options");
            builder.HasKey(q => q.Id);
            
            builder.Property(q => q.Question_text).IsRequired();
            builder.Property(q => q.Question_number).HasMaxLength(10);

            // Relaciones
            builder.HasOne(q => q.Chapter)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.Chapter_id);
        }
        
    }
}