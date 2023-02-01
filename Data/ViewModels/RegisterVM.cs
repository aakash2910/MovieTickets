using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confrim password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords do not match ")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
