using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Factory;
using Final_Indv_Assignment.Pages.Forms;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace Final_Indv_Assignment.Pages
{
    public class IndexModel : PageModel
    {
        public User user;
        private readonly LogInService _loginService;
        private readonly StationService _stationService;
        LogInService LS = FactoryService.createlogInUser();
        StationService SS = FactoryService.createStation();
        TicketService TS = FactoryService.createTicket();

        [BindProperty]
        public int Id { get; set; }
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
        public string StartingStationName { get; set; }

        [BindProperty]
        public string EndingStationName{ get; set; }
        [BindProperty]
        public double Distance { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        [BindProperty]
        public string DepartureDate { get; set; }
        [BindProperty]
        public string Time { get; set; }

        public Ticket Ticket;
        public List<Ticket> Tickets { get; set; }
    

        public void OnGet()
        {
            if(HttpContext.Session.Get("user_name") != null)
            {
                Username = HttpContext.Session.GetString("user_name")!;
            }
           
            

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
                var departureDate = DepartureDate;
                var time = Time;
                var id = Id++;

                // define Tickets here
                Tickets = new List<Ticket>();

                if (startingStation != null && endingStation != null)
                {
                    if (startingStation.Name != endingStation.Name)
                    {
                        Ticket = new Ticket(id,startingStation, endingStation, departureDate,time);
                        Tickets.AddRange(TS.GetAllTicketsByDepartureDate(startingStation, endingStation, departureDate, time)); // store result in a variable
                   
                   
                        StartingStationName = startingStation.Name;
                        EndingStationName = endingStation.Name; 
                        DepartureDate = departureDate;
                        Time = time;
                        SaveTickets();
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can't choose two same stations.");
                        SaveTickets();
                        return Page();
                    }
                    
                }

               

                return RedirectToPage("/Forms/Ticket");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return Page();
            }



        }
        public void SaveTickets()
        {
            var serializedTickets = JsonConvert.SerializeObject(Tickets);
            TempData["SerializedTickets"] = serializedTickets;
        }
    }
}