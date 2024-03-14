using System.ComponentModel.DataAnnotations;

namespace HotelBookingProject.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required!")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Password confirmation is required!")]
        [Compare("Password", ErrorMessage = "Password don't match!")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
