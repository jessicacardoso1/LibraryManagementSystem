using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<int> AddAsync(User user);
        Task UpdateAsync(User user);
        Task<bool> Exists(int id);
        Task<List<User>> GetAuthorsAsync();
        Task<User> GetUserByEmailAndPassordAsync(string email, string passwordHash);
        Task<User> GetUserByEmail(string email);

    }
}
