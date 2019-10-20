using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherLeague.Models;
using TeacherLeague.Repositories;

namespace TeacherLeague.Services
{
    public class UserService : IUserService
    {
        // IOC
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public Task DeleteAllUserInfoAsync()
        {
            return _userRepository.DeleteAllUserInfoAsync();
        }

        public Task DeleteUser(User user)
        {
            return _userRepository.DeleteUser(user);
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _userRepository.GetUserAsync(id);
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _userRepository.GetUserByEmailAsync(email);
        }

        public Task InsertUserAsync(User user)
        {
            return _userRepository.InsertUserAsync(user);
        }

        public Task UpdateUserAsync(User user)
        {
            return _userRepository.UpdateUserAsync(user);
        }
    }
}
