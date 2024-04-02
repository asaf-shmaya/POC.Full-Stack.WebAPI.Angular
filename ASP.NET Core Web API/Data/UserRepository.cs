using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllUsersWithInsurancePolicies()
        {
            return await _context.Users.Include(u => u.InsurancePolicies).ToListAsync();
        }

        public async Task<User> GetUserByIdWithInsurancePolicies(int id)
        {
            return await _context.Users.Include(u => u.InsurancePolicies).FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
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
