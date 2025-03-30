using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Repositories;
using LibraryManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryManagementSystemDbContext _context;
        public UserRepository(LibraryManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.User.AnyAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _context.User
                .Where(u => !u.IsDeleted)
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task UpdateAsync(User user)
        {

            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<User>> GetAuthorsAsync()
        {
            return await _context.User.Where(u => u.UserType == UserType.Author).ToListAsync();
        }

    }
}
