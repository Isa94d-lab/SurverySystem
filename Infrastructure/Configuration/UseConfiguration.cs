using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UseConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.id);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password_hash).IsRequired();

            builder.HasMany(u => u.User_roles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.User_id);
        }
        
    }
}