using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Factory;
using Final_Indv_Assignment.Pages.Forms;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Indv_Assignment.Pages
{
    public class IndexModel : PageModel
    {
        public User user;
        private readonly LogInService _loginService;
        LogInService LS = FactoryService.createlogInUser();

        [BindProperty]
        public string Username { get; private set; } = string.Empty;
        public void OnGet()
        {
            if(HttpContext.Session.Get("user_name") != null)
            {
                Username = HttpContext.Session.GetString("user_name")!;
            }
            //RegistrationModel.Equals(user, Username);


        }
    }
}