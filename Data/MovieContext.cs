// Data/MovieContext.cs
using Microsoft.EntityFrameworkCore;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

    public DbSet<Application> Movies { get; set; }

    public DbSet<Category> Categories { get; set; }
}

