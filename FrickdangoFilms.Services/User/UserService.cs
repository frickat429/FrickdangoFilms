using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FrickdangoFilms.Data;
using FrickdangoFilms.Models.User;

namespace FrickdangoFilms.Services.User
{
    public class UserService : IUserService
    {
        private readonly FrickdangoFilmsDbContext _context;

        public UserService(FrickdangoFilmsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    DateCreated = u.DateCreated
                })
                .ToListAsync();
        }

        public async Task<UserViewModel?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    DateCreated = u.DateCreated
                })
                .FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(UserCreateViewModel model)
        {
            var user = new Data.Entities.User
            {
                Username = model.Username,
                Email = model.Email,
                DateCreated = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(int id, UserCreateViewModel model)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Username = model.Username;
                user.Email = model.Email;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
