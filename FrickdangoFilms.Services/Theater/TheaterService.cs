using FrickdangoFilms.Data;
using FrickdangoFilms.Data.Entities;
using FrickdangoFilms.Models.Theater;
using Microsoft.EntityFrameworkCore;

namespace FrickdangoFilms.Services.Theater
{
    public class TheaterService : ITheaterService
    {
        private readonly FrickdangoFilmsDbContext _context;

        public TheaterService(FrickdangoFilmsDbContext context)
        {
            _context = context;
        }

        // Get all theaters
        public async Task<IEnumerable<TheaterViewModel>> GetAllTheaterAsync()
        {
            return await _context.Theaters
                .Select(t => new TheaterViewModel
                {
                    Id = t.Id,
                    TheaterName = t.TheaterName // Ensure this matches your ViewModel
                })
                .ToListAsync();
        }

        // Get a theater by Id
        public async Task<TheaterViewModel> GetTheaterByIdAsync(int id)
        {
            return await _context.Theaters
                .Where(t => t.Id == id)
                .Select(t => new TheaterViewModel
                {
                    Id = t.Id,
                    TheaterName = t.TheaterName // Ensure this matches your ViewModel
                })
                .FirstOrDefaultAsync();
        }
    }
}