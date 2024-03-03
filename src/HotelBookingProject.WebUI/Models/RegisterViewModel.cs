using System.ComponentModel.DataAnnotations;

namespace HotelBookingProject.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password don't match!")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
