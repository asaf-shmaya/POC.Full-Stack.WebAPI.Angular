namespace ASP.NET_Core_Web_API.Models
{
    public class InsurancePolicy
    {
        public int ID { get; set; } // Unique policy identifier
        public string PolicyNumber { get; set; } // Policy number
        public decimal InsuranceAmount { get; set; } // Insurance amount
        public DateTime StartDate { get; set; } // Start date of the policy
        public DateTime EndDate { get; set; } // End date of the policy
        public int UserID { get; set; } // Reference to the User ID
    }
}
