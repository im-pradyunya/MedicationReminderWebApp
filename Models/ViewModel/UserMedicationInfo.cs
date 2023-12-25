using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationReminder.Models.ViewModel
{
    public class UserMedicationInfo
    {
        [Required]
        [Key]
        public int MedicineId { get; set; }
      


        [Required]
        public string MedicineName { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public bool MorningDose { get; set; }

        [Required]
        public bool AfternoonDose { get; set; }
        [Required]
        public bool NightDose { get; set; }
        [Required]
        public TimeSpan MorningDoseTime { get; set; }
        [Required]
        public TimeSpan AfternoonDoseTime { get; set; }
        [Required]
        public TimeSpan NightDoseTime { get; set; }

        [Required]
        public string Email { get; set; }


        public string? Id { get; set; }
       
        public ApplicationUser? user { get; set; }





    }
}
