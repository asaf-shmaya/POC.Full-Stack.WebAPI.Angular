using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Web_API.Models
{
    public class User
    {
        public int ID { get; set; } // Unique user identifier
        public string Name { get; set; } // User's name
        public string Email { get; set; } // User's email
        public List<InsurancePolicy> InsurancePolicies { get; set; }

    }
}
