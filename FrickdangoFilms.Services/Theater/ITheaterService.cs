using FrickdangoFilms.Models.Theater;

namespace FrickdangoFilms.Services.Theater ; 

public interface ITheaterService 
{
    Task<IEnumerable<TheaterViewModel>> GetAllTheaterAsync();
    Task<TheaterViewModel>GetTheaterByIdAsync(int id) ;
}