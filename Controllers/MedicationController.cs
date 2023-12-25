using MedicationReminder.Database;
using MedicationReminder.Models;
using MedicationReminder.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace MedicationReminder.Controllers
{
    public class MedicationController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public MedicationController(AppDbContext context, UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
     

        [HttpGet]
        public IActionResult ViewMedications()
        {
            var email=User.Identity.Name;

            var res = context.UserMedicationInfos.Where(x => x.Email == email);


            return View(res);
        }

       

        public IActionResult MedicationDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> MedicationDetail(UserMedicationInfo model)
        {
            if(User.Identity.IsAuthenticated)
            {
               
              

                if (ModelState.IsValid)
                {
                    
                    var medicine = new UserMedicationInfo();
                    {
                        medicine.MedicineName = model.MedicineName;
                        medicine.FromDate = model.FromDate;
                        medicine.ToDate = model.ToDate;
                        medicine.Email = model.Email;   

                        medicine.MorningDose = model.MorningDose;
                        medicine.AfternoonDose = model.AfternoonDose;
                        medicine.NightDose = model.NightDose;
                        medicine.MorningDoseTime = model.MorningDoseTime;
                        medicine.AfternoonDoseTime = model.AfternoonDoseTime;
                        medicine.NightDoseTime = model.NightDoseTime;


                    };


                    context.UserMedicationInfos.Add(medicine);
                    await context.SaveChangesAsync();
                    return RedirectToAction("ViewMedications", "Medication");
                }
               


            }
            

            return View();
        }
    }
}
