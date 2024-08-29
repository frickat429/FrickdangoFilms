using FrickdangoFilms.Models.Theater;

namespace FrickdangoFilms.Services.Theater ; 

public interface ITheaterService 
{
    Task<IEnumerable<TheaterViewModel>> GetAllTheaterAsync();
    Task<TheaterViewModel>GetTheaterByIdAsync(int id) ;
    Task CreateTheaterAsync(TheaterCreateViewModel model);
    Task UpdateTheaterAsync(int id, TheaterEditVM model);
    Task DeleteTheaterAsync(int id);
}