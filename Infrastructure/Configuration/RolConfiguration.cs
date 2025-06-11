using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(r => r.Id);

            builder.Property(p => p.Name);
                   .IsRequired()
                   .HasMaxLength(80);
        }
    }
}