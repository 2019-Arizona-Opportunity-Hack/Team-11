using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TeacherLeague.Helpers;
using TeacherLeague.Models;
using Xamarin.Forms;

namespace TeacherLeague.Repositories
{
    public class UserRepository : IUserRepository
    {
        SQLiteAsyncConnection _connection;

        public UserRepository()
        {
            _connection = DependencyService.Get<ISQLiteHelper>().GetConnectionAsync();
            _connection.CreateTableAsync<User>();
        }

        public Task DeleteAllUserInfoAsync()
        {
            return _connection.DeleteAllAsync<User>();
        }

        public Task DeleteUser(User user)
        {
            return _connection.DeleteAsync(user);
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return _connection.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _connection.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _connection.Table<User>().Where(u => u.Email.Equals(email)).FirstAsync();
        }

        public Task InsertUserAsync(User user)
        {
            return _connection.InsertAsync(user);
        }

        public Task UpdateUserAsync(User user)
        {
            return _connection.UpdateAsync(user);
        }
    }
}
