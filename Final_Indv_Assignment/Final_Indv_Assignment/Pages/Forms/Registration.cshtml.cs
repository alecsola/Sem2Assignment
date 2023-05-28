using System.ComponentModel.DataAnnotations;
using Factory;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Indv_Assignment.Pages.Forms
{
    public class RegistrationModel : PageModel
    {

        public User user;
        private readonly LogInService _loginService;
        LogInService LS = FactoryService.createlogInUser();

        //[BindProperty]
        //public User User { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        [MinLength(6)]
        public string Password { get; set; }
        [BindProperty]
        [EmailAddress(ErrorMessage ="Geen geldig e-mailadres")]
        public string Email { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string BirthDate  { get; set; }
        [BindProperty]
        public string Adress { get; set; }

        public string Salt { get; private set; } 
        public string HashedPassword { get; private set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {

            
            
            // Call the RegisterUser method to add the user to the data source
            bool registrationSuccessful = LS.RegisterUser(Id,FirstName, LastName, Username,Password, Email, PhoneNumber, BirthDate, Adress);
                if (registrationSuccessful)
                {
                    // Redirect to the login page if registration was successful

                    return RedirectToPage("LogIn");
                 
                }
                else
                {
                    // Display an error message if registration failed
                    ViewData["ErrorMessage"] = "Registration failed. Please try again with a different username.";
                    return Page();
                }

        }
      
        

        private IActionResult View()
        {
            throw new NotImplementedException();
        }
    }
}
