using FrickdangoFilms.Models.Genre;

namespace FrickdangoFilms.Services.Genre ;

public interface IGenreService 
{
    Task<IEnumerable<GenreViewModel>> GetAllGenresAsync();
    Task<GenreViewModel> GetGenreByIdAsync(int id); 
    Task CreateGenreAsync(GenreCreateViewModel model);

    Task UpdateGenreAsync( int id, GenreEditVM model);

    Task DeleteGenreAsync(int id); 
}