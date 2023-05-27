using Factory;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Final_Indv_Assignment.Pages.Forms
{
    public class CartModel : PageModel
    {

        [BindProperty]
        public string Username { get; set; }    
        [BindProperty]
        public List<Product>products { get; set; }
        [BindProperty]
        public decimal totalPrice { get; set; }
        TicketService TS = FactoryService.createTicket();

        public void OnGet()
        {
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject <List<Product>>(cartJson);
                SaveCartToTempData();
                


            }
            if (HttpContext.Session.Get("user_name") != null)
            {
                Username = HttpContext.Session.GetString("user_name")!;
            }
           totalPrice = products.Sum(p => p.Price);
            

            
            

        }
        public IActionResult OnPostRemoveFromCart(int productId)
        {
            try
            {
                LoadCartFromTempData();
                var productToRemove = products.FirstOrDefault(p => p.Id == productId);
                if (productToRemove != null)
                {
                    products.Remove(productToRemove);
                }
                totalPrice = products.Sum(p => p.Price);
                SaveCartToTempData();

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
                LoadCartFromTempData();

                products.Clear();
                

                SaveCartToTempData();

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

    }
}
