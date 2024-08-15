using FrickdangoFilms.Data;
using FrickdangoFilms.Data.Entities;
using FrickdangoFilms.Models.Movies;
using Microsoft.EntityFrameworkCore;

namespace FrickdangoFilms.Services.Movie ;

public class MovieService : IMovieService
{
    private readonly FrickdangoFilmsDbContext _context;

    public MovieService(FrickdangoFilmsDbContext context)
    {
        _context = context;
    }

    // Read All
    public async Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync()
    {
        return await _context.Movies
                             .Select(m => new MovieViewModel
                             {
                                 Id = m.Id,
                                 MovieTitle = m.MovieTitle,
                                 MovieDescription = m.MovieDescription,
                                 RuntimeInMinutes = m.RuntimeInMinutes,
                                 MovieGenre = m.Genre.MovieGenre,
                                 MPAA_Rating = m.MPAA_Rating.MovieRating,
                                 TheaterName = m.Theater.TheaterName
                             })
                             .ToListAsync();
    }

    // Read by Id
public async Task<MovieViewModel?> GetMovieByIdAsync(int id)
{
    return await _context.Movies
                         .Where(m => m.Id == id)
                         .Select(m => new MovieViewModel
                         {
                             Id = m.Id,
                             MovieTitle = m.MovieTitle,
                             MovieDescription = m.MovieDescription,
                             RuntimeInMinutes = m.RuntimeInMinutes,
                             MovieGenre = m.Genre.MovieGenre,
                             MPAA_Rating = m.MPAA_Rating.MovieRating,
                             TheaterName = m.Theater.TheaterName
                         })
                         .FirstOrDefaultAsync();
}
    // Create
    public async Task CreateMovieAsync(MovieCreateViewModel model)
    {
        var movie = new Movies
        {
            MovieTitle = model.MovieTitle,
            MovieDescription = model.MovieDescription,
            RuntimeInMinutes = model.RuntimeInMinutes,
            GenreId = model.GenreId,
            MPAA_RatingId = model.MPAA_RatingId,
            TheaterId = model.TheaterId
        };

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
    }

    // Update
    public async Task UpdateMovieAsync(int id, MovieEditViewModel model)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            movie.MovieTitle = model.MovieTitle;
            movie.MovieDescription = model.MovieDescription;
            movie.RuntimeInMinutes = model.RuntimeInMinutes;
            movie.GenreId = model.GenreId;
            movie.MPAA_RatingId = model.MPAA_RatingId;
            movie.TheaterId = model.TheaterId;

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
    }

    // Delete
    public async Task DeleteMovieAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}