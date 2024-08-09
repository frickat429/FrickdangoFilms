using FrickdangoFilms.Models.Genre;
using FrickdangoFilms.Models.Movies;
using FrickdangoFilms.Models.MPAA_Rating;
using FrickdangoFilms.Models.Theater;

namespace FrickdangoFilms.Services.Movie ;

public interface IMovieService 
{
  Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync();
    Task<MovieViewModel> GetMovieByIdAsync(int id);
    Task CreateMovieAsync(MovieCreateViewModel model);
    Task UpdateMovieAsync(int id, MovieEditViewModel model);
    Task DeleteMovieAsync(int id);
}