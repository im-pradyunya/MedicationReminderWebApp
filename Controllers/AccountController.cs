using MedicationReminder.Models;
using MedicationReminder.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicationReminder.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

      
       

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email ,Name=model.Name};
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }

            }


            return View(model);
        }

        public IActionResult Login()
        {

            if(signInManager.IsSignedIn(User))
             {
                TempData["AlertMessage"] = "You are already logged in.";
                return RedirectToAction("PatientDetails", "Account");


             }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {


                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
             

                if (result.Succeeded)
                {
                    return RedirectToAction("PatientDetails", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }



            }
            return View(model);
        }

        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }



        public IActionResult PatientDetails()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PatientDetails(PatientInfo model)
        {

            if (ModelState.IsValid)
            {

                var user = await userManager.GetUserAsync(User);


                if (user != null)
                {
                 
                    user.Gender = model.Gender;
                    user.Age=model.Age;
                    user.Height=model.Height;   
                    user.Weight=model.Weight;
                  
                    user.Exercise=model.Exercise;
                    user.PresentDisease=model.PresentDisease;
                    user.PastDisease=model.PastDisease;
                    

                    var result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("index", "Home"); 
                    }

                }
                else
                {
                    ModelState.AddModelError("", "User not found");
                }
            }

            return View(model);

        }




    }
}
