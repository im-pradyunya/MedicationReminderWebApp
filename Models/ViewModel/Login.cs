using System.ComponentModel.DataAnnotations;

namespace MedicationReminder.Models.ViewModel
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
    }
}
