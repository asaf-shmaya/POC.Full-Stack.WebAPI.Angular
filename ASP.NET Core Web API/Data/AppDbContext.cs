using ASP.NET_Core_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data
{
    public class AppDbContext : DbContext
    {
        // DbContext members will be added here
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
    }

}
