using FrickdangoFilms.Data;
using FrickdangoFilms.Data.Entities;
using FrickdangoFilms.Models.MPAA_Rating;
using Microsoft.EntityFrameworkCore;

namespace FrickdangoFilms.Services.MPAA_Rating
{
    public class MPAA_RatingService : IMPAA_RatingService
    {
        private readonly FrickdangoFilmsDbContext _context;

        public MPAA_RatingService(FrickdangoFilmsDbContext context)
        {
            _context = context;
        }

        // Get all MPAA ratings
        public async Task<IEnumerable<MPAA_RatingViewModel>> GetAllMPAARatingAsync()
        {
            return await _context.MPAA_Ratings
                .Select(r => new MPAA_RatingViewModel
                {
                    Id = r.Id,
                    MovieRating = r.MovieRating // Ensure this matches your ViewModel property
                })
                .ToListAsync();
        }

        // Get an MPAA rating by Id
        public async Task<MPAA_RatingViewModel> GetMPAARatingByIdAsync(int id)
        {
            return await _context.MPAA_Ratings
                .Where(r => r.Id == id)
                .Select(r => new MPAA_RatingViewModel
                {
                    Id = r.Id,
                    MovieRating = r.MovieRating // Ensure this matches your ViewModel property
                })
                .FirstOrDefaultAsync();
        }
    }
}

