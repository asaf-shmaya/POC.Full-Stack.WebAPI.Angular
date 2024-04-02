using ASP.NET_Core_Web_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Core_Web_API.Interfaces
{
    public interface IUserRepository
    {
        // Retrieve all users
        Task<IEnumerable<User>> GetAllUsers();

        Task<List<User>> GetAllUsersWithInsurancePolicies();
        Task<User> GetUserByIdWithInsurancePolicies(int id);

        // Retrieve a user by ID
        Task<User> GetUserById(int id);

        // Create a new user
        Task CreateUser(User user);

        // Update an existing user
        Task UpdateUser(User user);

        // Delete a user by ID
        Task DeleteUser(int id);
    }
}
