namespace ASP.NET_Core_Web_API.Models.Dto
{
    public class InsurancePolicyUpdateDto
    {
        public string PolicyNumber { get; set; }
        public double InsuranceAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
