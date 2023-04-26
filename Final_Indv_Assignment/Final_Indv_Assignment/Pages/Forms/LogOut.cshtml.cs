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

namespace Final_Indv_Assignment.Pages.Shared
{
    public class LogOutModel : PageModel
    {
        
        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }
        
    }
}
