using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Factory;
using Final_Indv_Assignment.Pages.Forms;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace Final_Indv_Assignment.Pages
{
    public class IndexModel : PageModel
    {
        public User user;
        private readonly LogInService _loginService;
        private readonly StationService _stationService;
        LogInService LS = FactoryService.createlogInUser();
        StationService SS = FactoryService.createStation();


        [BindProperty]
        public string Username { get; private set; } = string.Empty;
        [BindProperty]
        public string StationName { get; private set; }
        [BindProperty]
        public string Latitude { get; private set; }
        [BindProperty]
        public string Longitude { get; private set; }
        [BindProperty]
        public int StartingStationId { get; set; }

        [BindProperty]
        public int EndingStationId { get; set; }
        [BindProperty]
        public double Distance { get; set; }
        [BindProperty]
        public decimal Price { get; set; }

        public Tickets Tickets { get; set; }



        public void OnGet()
        {
            if(HttpContext.Session.Get("user_name") != null)
            {
                Username = HttpContext.Session.GetString("user_name")!;
            }
            //RegistrationModel.Equals(user, Username);
            

        }
        public List<Station> stations
        {
            get { return SS.GetAllStations(); }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var startingStation = stations.FirstOrDefault(s => s.Id == StartingStationId);
                var endingStation = stations.FirstOrDefault(s => s.Id == EndingStationId);

                if (startingStation != null && endingStation != null)
                {
                    Tickets = new Tickets(startingStation, endingStation);
                    Distance = Tickets.Distance;
                    Price = Tickets.Price;
                }
                return Page();
            }
            catch
            {
                ModelState.AddModelError("", "Incorrect username or password. Please try again.");
                return Page();
            }
            

            
        }
    }
}