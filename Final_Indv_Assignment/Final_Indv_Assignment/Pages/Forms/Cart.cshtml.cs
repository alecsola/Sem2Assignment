using Factory;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileSystemGlobbing;
using Newtonsoft.Json;

namespace Final_Indv_Assignment.Pages.Forms
{
    public class CartModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public int UserId { get; set; }
        public User user { get; set; }
        public string PriceText { get; set; }
        public List<string> ProductName { get; set; }
        [BindProperty]
        public List<Product>products { get; set; }
        public List<Payment> payments { get; set; }
       
        public decimal totalPrice { get; set; }
        
        PaymentService PS = FactoryService.createPayment();
        LogInService LS = FactoryService.createlogInUser();

        public void OnGet()
        {
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject <List<Product>>(cartJson);
                totalPrice = (products.Sum(p => p.Price));
                SaveCartToTempData();

            }
            if (TempData.TryGetValue("SerializedUser", out var serializedUser) && serializedUser is string userJson)
            {
                user = JsonConvert.DeserializeObject<User>(userJson);
                if(user != null)
                {
                    UserId = user.Id;

                }
                
                LoadCartFromTempData();
                if(CheckIfUserHasSeasonTicket())
                {
                    totalPrice = 0;
                    
                }
                else
                {
                    totalPrice = (products.Sum(p => p.Price));
                }
                SaveCartToTempData();
                SaveUser();
            }

            
            

            
            

        }
        public IActionResult OnPostRemoveFromCart(int productId)
        {
            try
            {
                LoadUser();
                LoadCartFromTempData();
                var productToRemove = products.FirstOrDefault(p => p.Id == productId);
                if (productToRemove != null)
                {
                    products.Remove(productToRemove);
                }
                if (CheckIfUserHasSeasonTicket())
                {
                    totalPrice = 0;
                    PriceText = "Since you have a Season Ticket this order is free.";
                }
                else
                {
                    totalPrice = (products.Sum(p => p.Price));
                }
                SaveCartToTempData();
                SaveUser();

                return Page();
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "An error occurred while removing the product from the cart.");
                return Page();
            }
        }


        public IActionResult OnPostCheckout()
        {
            try
            {
                LoadUser();
                
                LoadCartFromTempData();
                if(UserId != 0)
                {
                    
                    List<string> productNames = new List<string>();
                    
                    if (CheckIfUserHasSeasonTicket())
                    {
                        totalPrice = 0;
                        PriceText = "Since you have a Season Ticket this order is free.";
                    }
                    else
                    {
                        totalPrice = (products.Sum(p => p.Price));
                    }
                    foreach (Product product in products)
                    {
                        productNames.Add(product.Name);
                    
                    }
                    
                    Payment payment = new Payment(Id, UserId, totalPrice, productNames);
                    var AddedPayment = PS.AddPayment(payment);
                    totalPrice = 0;
                    PriceText = null;
                    products.Clear();

                    SaveUser();   
                    SaveCartToTempData();
                    

                }


                return Page();
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "An error occurred during the checkout process.");
                return Page();
            }
        }




        private void LoadCartFromTempData()
        {
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cartJson);
            }
            else
            {
                products = new List<Product>();
            }
        }

        private void SaveCartToTempData()
        {
            var serializedCart = JsonConvert.SerializeObject(products);
            TempData["SerializedCart"] = serializedCart;
        }

        private void LoadUser()
        {
            if (TempData.TryGetValue("SerializedUser", out var serializedUser) && serializedUser is string userJson)
            {
                user = JsonConvert.DeserializeObject<User>(userJson);
                if(user != null)
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
        private bool CheckIfUserHasSeasonTicket()
        {
            if (PS.CheckIfUserProduct(UserId) == true)
            {
                totalPrice = 0;
                PriceText = "Since you have a Season Ticket this order is free.";
            }
            else
            {
                return false;
            }
            return true;
        }

    }
}
