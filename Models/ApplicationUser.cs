using MedicationReminder.Controllers;
using MedicationReminder.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace MedicationReminder.Models
{
    public class ApplicationUser:IdentityUser
    {


        public string? Name { get; set; }


        public int? Age { get; set; }
        public string? Gender { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? Meditation { get; set; }

        public string? Exercise { get; set; }
        public string? PresentDisease { get; set; }
        public string? PastDisease { get; set; }

        public ICollection<UserMedicationInfo> MedicinceInfo { get; set; }



    }
}
