using FrickdangoFilms.Models.MPAA_Rating;

namespace FrickdangoFilms.Services.MPAA_Rating ;

public interface IMPAA_RatingService
{
    Task<IEnumerable<MPAA_RatingViewModel>> GetAllMPAARatingAsync();
    Task<MPAA_RatingViewModel> GetMPAARatingByIdAsync(int id) ;
    Task CreateMovieRatingAsync(MPAA_RatingCreateViewModel model);
}