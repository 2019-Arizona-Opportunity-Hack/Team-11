using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherLeague.Models;

namespace TeacherLeague.Services
{
    public interface IUserAccountsService
    {
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string email);
        Task InsertUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUser(User user);
    }
}
