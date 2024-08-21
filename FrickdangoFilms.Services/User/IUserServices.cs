using System.Threading.Tasks;
using System.Collections.Generic;
using FrickdangoFilms.Models.User;

namespace FrickdangoFilms.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel?> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserCreateViewModel model);
        Task UpdateUserAsync(int id, UserCreateViewModel model);
        Task DeleteUserAsync(int id);
    }
}