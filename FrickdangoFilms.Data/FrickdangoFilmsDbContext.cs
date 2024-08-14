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

        //Seed data 

        //Genre Data
        modelBuilder.Entity<Genre>().HasData(
            new Genre {Id = 1, MovieGenre = "Action" }, 
            new Genre {Id = 2, MovieGenre = "Romcom"}, 
            new Genre {Id = 3, MovieGenre = "Science Fiction"},
            new Genre {Id = 4, MovieGenre = "Horror"}, 
            new Genre {Id = 5, MovieGenre = "Thriller"},
            new Genre {Id = 6, MovieGenre = "Comedy" }

        ); 
        //MPAA Rating Data 
        modelBuilder.Entity<MPAA_Rating>().HasData(
            new MPAA_Rating {Id = 1, MovieRating = "G"},
            new MPAA_Rating {Id = 2, MovieRating = "PG"}, 
            new MPAA_Rating {Id = 3, MovieRating = "PG-13"}, 
            new MPAA_Rating {Id = 4, MovieRating = "R"}
        ); 

        //Theater Name data 
        modelBuilder.Entity<Theater> ().HasData(
            new Theater {Id = 1, TheaterName = "Atlantica"}, 
            new Theater {Id = 2, TheaterName = "Star Rail"},
            new Theater {Id = 3, TheaterName = "Ringo"},
            new Theater {Id = 4, TheaterName = "Arkride"},
            new Theater {Id = 5, TheaterName = "Columbia"},
            new Theater {Id = 6, TheaterName = "Rainbow Road"}
        ); 

        base.OnModelCreating(modelBuilder);


    }
}