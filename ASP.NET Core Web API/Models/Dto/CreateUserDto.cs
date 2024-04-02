using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Web_API.Models.Dto
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; } // User's name
        [Required]
        [EmailAddress]
        public string Email { get; set; } // User's email
    }
}