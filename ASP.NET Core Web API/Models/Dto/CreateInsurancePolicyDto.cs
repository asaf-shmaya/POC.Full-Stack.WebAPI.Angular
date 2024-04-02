namespace ASP.NET_Core_Web_API.Models.Dto
{
    public class CreateInsurancePolicyDto
    {
        public string PolicyNumber { get; set; }
        public double InsuranceAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserID { get; set; } // Assuming this is the ID of the user associated with the policy
    }
}