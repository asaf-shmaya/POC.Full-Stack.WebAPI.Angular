using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API.Data
{
    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private readonly AppDbContext _context;

        public InsurancePolicyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InsurancePolicy>> GetAllInsurancePolicies()
        {
            return await _context.InsurancePolicies.ToListAsync();
        }

        public async Task<InsurancePolicy> GetInsurancePolicyById(int id)
        {
            return await _context.InsurancePolicies.FindAsync(id);
        }

        public async Task CreateInsurancePolicy(InsurancePolicy policy)
        {
            _context.InsurancePolicies.Add(policy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInsurancePolicy(InsurancePolicy policy)
        {
            _context.Entry(policy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInsurancePolicy(int id)
        {
            var policy = await _context.InsurancePolicies.FindAsync(id);
            if (policy != null)
            {
                _context.InsurancePolicies.Remove(policy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
