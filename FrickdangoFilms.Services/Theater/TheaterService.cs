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
                    TheaterName = t.TheaterName 
                })
                .ToListAsync();
        }

        // Get a theater by Id
public async Task<TheaterViewModel?> GetTheaterByIdAsync(int id)
    {
    return await _context.Theaters
        .Where(t => t.Id == id)
        .Select(t => new TheaterViewModel
        {
            Id = t.Id,
            TheaterName = t.TheaterName
        })
        .FirstOrDefaultAsync();
    }

    public async Task CreateTheaterAsync(TheaterCreateViewModel model)
    {
        var theater = new Data.Entities.Theater
        {
            TheaterName = model.TheaterName
        };
        _context.Theaters.Add(theater);
        await _context.SaveChangesAsync();
    }

    //Edit 
    public async Task UpdateTheaterAsync(int id, TheaterEditVM model) 
    {
        var theater = await _context.Theaters.FindAsync(id);
        if (theater != null) 
        {
            theater.TheaterName = model.TheaterName;
            _context.Theaters.Update(theater);
            await _context.SaveChangesAsync();
        }
    }
    //Delete 
    public async Task DeleteTheaterAsync(int id) 
    {
        var theater = await _context.Theaters.FindAsync(id);
        if(theater != null) 
        {
            _context.Theaters.Remove(theater);
            await _context.SaveChangesAsync();
        }
    }
    }
}