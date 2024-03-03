using System.ComponentModel.DataAnnotations;

namespace HotelBookingProject.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string? Password {  get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
