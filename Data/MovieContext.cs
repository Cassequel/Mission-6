using Microsoft.EntityFrameworkCore;
using Mission__6.Models;

namespace Mission__6.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<Application> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("Movies");
            modelBuilder.Entity<Category>().ToTable("Categories");
        }
    }
}