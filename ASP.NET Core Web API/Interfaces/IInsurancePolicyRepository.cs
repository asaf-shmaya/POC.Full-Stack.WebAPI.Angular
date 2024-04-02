using ASP.NET_Core_Web_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ASP.NET_Core_Web_API.Interfaces;

public interface IInsurancePolicyRepository
{
    // Retrieve all insurance policies
    Task<IEnumerable<InsurancePolicy>> GetAllInsurancePolicies();

    // Retrieve an insurance policy by ID
    Task<InsurancePolicy> GetInsurancePolicyById(int id);

    // Create a new insurance policy
    Task CreateInsurancePolicy(InsurancePolicy policy);

    // Update an existing insurance policy
    Task UpdateInsurancePolicy(InsurancePolicy policy);

    // Delete an insurance policy by ID
    Task DeleteInsurancePolicy(int id);
}

