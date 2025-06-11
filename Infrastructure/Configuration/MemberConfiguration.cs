using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<UserMember>
    {
        builder.ToTable("members");
            builder.HasKey(e => e.Id); // Asumiendo que 'Id' es la clave primaria
            builder.Property(p => p.Id)
                    .IsRequired()
                    .HasMaxLength(20);

            builder.Property(p => p.Username)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.HasMany(p => p.RefreshTokens)
                    .WithOne(p => p.Users)
                    .HasForeignKey(p => p.MemberId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
}