using FrickdangoFilms.Data;
using FrickdangoFilms.Data.Entities;
using FrickdangoFilms.Models.Genre;
using Microsoft.EntityFrameworkCore;

namespace FrickdangoFilms.Services.Genre
{
    public class GenreService : IGenreService
    {
        private readonly FrickdangoFilmsDbContext _context;

        public GenreService(FrickdangoFilmsDbContext context)
        {
            _context = context;
        }

        // Get all genres
        public async Task<IEnumerable<GenreViewModel>> GetAllGenresAsync()
        {
            return await _context.Genres
                .Select(g => new GenreViewModel
                {
                    GenreId = g.Id,
                    MovieGenre = g.MovieGenre // Ensure the property name matches the ViewModel
                })
                .ToListAsync();
        }

        // Get a genre by Id
public async Task<GenreViewModel?> GetGenreByIdAsync(int id)
{
    return await _context.Genres
        .Where(g => g.Id == id)
        .Select(g => new GenreViewModel
        {
            GenreId = g.Id,
            MovieGenre = g.MovieGenre 
        })
        .FirstOrDefaultAsync();
}

        //Create new genre 
        public async Task CreateGenreAsync(GenreCreateViewModel model) 
        {
            var genre = new Data.Entities.Genre
            {
                MovieGenre = model.MovieGenre
            }; 
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }


    }
}