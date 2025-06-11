using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(r => r.id);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(r => r.user_roles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.Role_id);
        }
        
    }
}