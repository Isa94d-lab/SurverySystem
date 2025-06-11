using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class Use_roleConfiguration : IEntityTypeConfiguration<User_role>
    {
        public void Configure(EntityTypeBuilder<User_role> builder)
        {
            builder.ToTable("user_roles");
            builder.HasKey(ur => new { ur.User_id, ur.Role_id });

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.User_roles)
                .HasForeignKey(ur => ur.User_id);

            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.user_roles)
                .HasForeignKey(ur => ur.Role_id);
        }

    }
}