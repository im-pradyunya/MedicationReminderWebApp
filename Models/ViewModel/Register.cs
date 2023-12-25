using System.ComponentModel.DataAnnotations;

namespace MedicationReminder.Models.ViewModel
{
    public class Register
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Conform Password")]
        [Compare("Password",
            ErrorMessage = "Password and Confirmation Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
