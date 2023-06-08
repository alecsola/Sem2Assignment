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
            //if(HttpContext.Session.Get("user_name") != null)
            //{
            //    Username = HttpContext.Session.GetString("user_name")!;
            //}56
            
            if (TempData.TryGetValue("SerializedUser", out var serializedUser) && serializedUser is string cartJson)
            {
                
                user = JsonConvert.DeserializeObject<User>(cartJson);
                if(user!= null)
                {
                    Username = user.Username;
                }
                
                var SerializedUser = JsonConvert.SerializeObject(user);
                TempData["SerializedUser"] = SerializedUser;
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

                if (startingStation != null && endingStation != null && departureDate !=null)
                {
                    if (startingStation.Name != endingStation.Name)
                    {
                        Ticket = new Ticket(id,startingStation, endingStation, departureDate,time);
                        Tickets.AddRange(TS.GetFilteredTickets(startingStation, endingStation, departureDate, time)); // store result in a variable
                   
                   
                        StartingStationName = startingStation.Name;
                        EndingStationName = endingStation.Name; 
                        DepartureDate = departureDate;
                        Time = time;
                        SaveTickets();
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("Error", "You can't choose two same stations.");
                        SaveTickets();
                        return Page();
                    }
                    
                }
                else
                {
                    ModelState.Clear();
                    ModelState.AddModelError("Error", "You haven't chosen the fields correctly");
                    return Page();
                }

               
                if(Tickets.Count > 0)
                {
                    return RedirectToPage("/Forms/Ticket");
                }
                else
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "No tickets found.");
                    return Page();
                }
                
            }
            catch
            {
                ModelState.Clear();
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