using System.Text;
using Factory;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Final_Indv_Assignment.Pages.Forms
{
    public class TicketModel : PageModel
    {
        [BindProperty]
        public List<Ticket> Tickets { get; set; }
        [BindProperty]
     
        public List<Product> products { get; set; }
        [BindProperty]
        public int ProductId { get; set; }
       
        TicketService TS = FactoryService.createTicket();

        public void OnGet()
        { 
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cartJson);
                SaveProducts();

            }
            
            if (TempData.TryGetValue("SerializedTickets", out var serializedTickets) && serializedTickets is string ticketsJson)
            {
                
                // Deserialize the JSON string to the Tickets list
                Tickets = JsonConvert.DeserializeObject<List<Ticket>>(ticketsJson);
          
                SaveTickets();

            }
            else
            {
                // If the Tickets don't exist in session, initialize an empty list
                Tickets = new List<Ticket>();
            }
           

        }
        
        public IActionResult OnPostAddToCart(int productId)
        {
            try
            {
                LoadTickets();
                products = new List<Product>();
                LoadProducts();
                var selectedTicket = TS.GetTicketById(productId);
                if (selectedTicket != null)
                {
                    var product = new Product
                    {
                        Id = selectedTicket.Id,
                    
                        Name = $"{selectedTicket.StartingStation.Name} - {selectedTicket.DestinationStation.Name} --- Date: {selectedTicket.DepartureDate} {selectedTicket.Time} ---",
                        Price = selectedTicket.Price
                    };

                    products.Add(product);
                    SaveProducts();
                }
                SaveTickets();
            
                return Page(); 
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return Page();
            }
            
        }


        public void LoadTickets()
        {
            if (TempData.TryGetValue("SerializedTickets", out var SerializedTickets) && SerializedTickets is string ticketsJson)
            {
                Tickets = JsonConvert.DeserializeObject<List<Ticket>>(ticketsJson);
            }
        }
        public void LoadProducts()
        {
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cartJson);

            }
        }
        public void SaveTickets()
        {
            var serializedTickets = JsonConvert.SerializeObject(Tickets);
            TempData["SerializedTickets"] = serializedTickets;
        }
        public void SaveProducts()
        {
            var SerializedCart = JsonConvert.SerializeObject(products);
            TempData["SerializedCart"] = SerializedCart;
        }
    }
}
