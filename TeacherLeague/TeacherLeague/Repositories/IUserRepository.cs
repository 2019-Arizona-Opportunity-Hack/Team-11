using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherLeague.Models;

namespace TeacherLeague.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task InsertUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteAllUserInfoAsync();
        Task DeleteUser(User user);
    }
}
