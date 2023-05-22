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
        public Cart cart;
        TicketService TS = FactoryService.createTicket();

        public void OnGet()
        {
            
            if (TempData.TryGetValue("SerializedTickets", out var serializedTickets) && serializedTickets is string ticketsJson)
            {
                
                // Deserialize the JSON string to the Tickets list
                Tickets = JsonConvert.DeserializeObject<List<Ticket>>(ticketsJson);
                // You can now access the Tickets list in the current page
                var SerializedTickets = JsonConvert.SerializeObject(Tickets);
                TempData["SerializedTickets"] = SerializedTickets;

            }
            else
            {
                // If the Tickets don't exist in session, initialize an empty list
                Tickets = new List<Ticket>();
            }
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cartJson);


            }

        }
        
        public IActionResult OnPostAddToCart(int productId)
        {
            if (TempData.TryGetValue("SerializedTickets", out var SerializedTickets) && SerializedTickets is string ticketsJson)
            {
            Tickets = JsonConvert.DeserializeObject<List<Ticket>>(ticketsJson);
            }
            
            products = new List<Product>();
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cartJson);

            }
            var selectedTicket = TS.GetTicketById(productId);
            if (selectedTicket != null)
            {
                var product = new Product
                {
                    Id = selectedTicket.Id,
                    
                    Name = $"{selectedTicket.StartingStation.Name} - {selectedTicket.DestinationStation.Name} - {selectedTicket.DepartureDate} - {selectedTicket.Time}",
                    Price = selectedTicket.Price
                };

                products.Add(product);
                var SerializedCart = JsonConvert.SerializeObject(products);
                TempData["SerializedCart"] = SerializedCart;
            }
            var serializedTickets = JsonConvert.SerializeObject(Tickets);
            TempData["SerializedTickets"] = serializedTickets;
            
            return Page(); 
        }
    }
}
