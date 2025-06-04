using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Surveys> Surveys { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Sub_questions> Sub_questions { get; set; }
        public DbSet<Option_questions> Option_questions { get; set; }
        public DbSet<Options_response> Options_response { get; set; }
        public DbSet<Categories_catalog> Categories_catalog { get; set; }
        public DbSet<Category_options> Category_options { get; set; }
        public DbSet<Sumaryoptions> Sumaryoptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
