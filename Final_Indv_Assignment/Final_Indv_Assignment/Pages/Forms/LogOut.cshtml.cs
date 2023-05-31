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

namespace Final_Indv_Assignment.Pages.Shared
{
    public class LogOutModel : PageModel
    {
        public User user { get; set; }
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync();
            var SerializedUser = JsonConvert.SerializeObject(user);
            TempData["SerializedUser"] = SerializedUser;
            return RedirectToPage("/Index");
        }
        
    }
}
