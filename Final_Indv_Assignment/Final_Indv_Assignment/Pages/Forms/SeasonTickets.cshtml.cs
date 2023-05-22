using Factory;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Final_Indv_Assignment.Pages.Forms
{
    public class SeasonTicketsModel : PageModel
    {
       
        private SeasonTicketsService seasonTicketsService;
        SeasonTicketsService STS = FactoryService.createseasonTickets();
        //SeasonTickets seasonTickets = new List<SeasonTickets>();
        [BindProperty]
        public List<Product> products { get; set; }


        private readonly ILogger<IndexModel> _logger;

        public SeasonTicketsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cartJson);
               
            }
            


        }
        public IActionResult OnPostAddToCart(int productId)
        {

            products = new List<Product>();
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cartJson);

            }
            var selectedTicket = STS.GetSeasonTicketById(productId);
            if (selectedTicket != null)
            {
                var product = new Product
                {
                    Id = selectedTicket.Id,

                    Name = $"{selectedTicket.SeasonTicketName}",
                    Price = selectedTicket.Price
                };

                products.Add(product);
                var SerializedCart = JsonConvert.SerializeObject(products);
                TempData["SerializedCart"] = SerializedCart;
            }

            return Page();
        }
        public List<SeasonTickets> seasonTickets
        {
            get { return STS.GetAllSeasonTickets(); }
        }
        
    }
}