using FrickdangoFilms.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrickdangoFilms.Data;

public class FrickdangoFilmsDbContext : DbContext 
{
    public FrickdangoFilmsDbContext(DbContextOptions<FrickdangoFilmsDbContext>options) 
    : base(options) 
    {
    }
        public DbSet<User> Users { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MPAA_Rating> MPAA_Ratings { get; set; } 
        public DbSet<Theater> Theaters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Movies>() 
        .HasOne(m => m.Genre) 
        .WithMany() 
        .HasForeignKey(m => m.GenreId);
        
        modelBuilder.Entity<Movies>() 
        .HasOne(m => m.MPAA_Rating)
        .WithMany() 
        .HasForeignKey(m => m.MPAA_RatingId);

        modelBuilder.Entity<Movies>() 
        .HasOne(m => m.Theater) 
        .WithMany() 
        .HasForeignKey(m => m.TheaterId);
        base.OnModelCreating(modelBuilder);
    }
}