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
        
        PaymentService PS = FactoryService.createPayment();
        
        //SeasonTickets seasonTickets = new List<SeasonTickets>();
        [BindProperty]
        public List<Product> products { get; set; }
        public User user;
        public int UserId;
        public List<Payment>payments { get; set; }
        

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
                SaveProducts();
            }
            if (TempData.TryGetValue("SerializedUser", out var serializedUser) && serializedUser is string userJson)
            {
                user = JsonConvert.DeserializeObject<User>(userJson);
                if (user != null)
                {
                    UserId = user.Id;

                }
                SaveUser();
            }



        }
        public List<SeasonTickets> seasonTickets
        {
            get { return STS.GetAllSeasonTickets(); }
        }
        public IActionResult OnPostAddToCart(int productId)
        {
            payments = new List<Payment>();
            products = new List<Product>();
            LoadProducts();
            LoadUser();
            payments = PS.CheckIfUserSeasonTicket(UserId);
            if (payments.Count == 0)
            {
                var selectedTicket = STS.GetSeasonTicketById(productId);
                if (selectedTicket != null)
                {
                    var product = new Product
                    {
                        Id = selectedTicket.Id,

                        Name = $"{selectedTicket.SeasonTicketName}",
                        Price = Math.Round(selectedTicket.Price)

                    };
      
                    products.Add(product);
                    SaveProducts();
                    SaveUser();
                }
                return Page();
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("", "You already have a Season Ticket to your name.");
                SaveProducts();
                SaveUser();
                return Page();
                
            }
           

            
        }
        




        public void LoadProducts()
        {
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cartJson);

            }
        }
        public void SaveProducts()
        {
            var SerializedCart = JsonConvert.SerializeObject(products);
            TempData["SerializedCart"] = SerializedCart;
        }
        private void LoadUser()
        {
            if (TempData.TryGetValue("SerializedUser", out var serializedUser) && serializedUser is string userJson)
            {
                user = JsonConvert.DeserializeObject<User>(userJson);
                if (user != null)
                {
                    UserId = user.Id;
                }

            }
        }
        private void SaveUser()
        {
            var SerializedUser = JsonConvert.SerializeObject(user);
            TempData["SerializedUser"] = SerializedUser;
        }
        



    }
}