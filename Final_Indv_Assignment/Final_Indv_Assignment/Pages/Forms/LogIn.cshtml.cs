using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Factory;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace Final_Indv_Assignment.Pages.Shared
{
    public class LogInModel : PageModel
    {
        public User user;
        
        LogInService LS = FactoryService.createlogInUser();

        [BindProperty]
        
        public string Username { get; set; }

        [BindProperty]
        
        public string Password { get; set; }

        public IActionResult OnPostSignUp()
        {
            return RedirectToPage("/Forms/Registration");
        }


        public async Task<IActionResult> OnPostAsync()
        {
            User loggedInUser = (LS.ValidateUserCredentials(Username, Password,"2"));

            if(ModelState.IsValid && loggedInUser != null)
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Username)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                HttpContext.Session.SetString("user_name", Username);
                var serializedUser = JsonConvert.SerializeObject(loggedInUser);
                TempData["SerializedUser"] = serializedUser;
                return RedirectToPage("/Index");//,new { username = loggedInUser.Username });
                
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("", "Incorrect username or password. Please try again.");
                return Page();
            }

            

            


        }
    }
}
