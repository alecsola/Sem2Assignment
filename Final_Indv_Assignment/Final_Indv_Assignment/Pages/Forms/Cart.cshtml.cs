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
        public int Id { get; set; }
        [BindProperty]
        public int UserId { get; set; }
       
       
        public List<string> ProductName { get; set; }
        [BindProperty]
        public List<Product>products { get; set; }
       
        public string totalPrice { get; set; }
        
        PaymentService PS = FactoryService.createPayment();
        LogInService LS = FactoryService.createlogInUser();

        public void OnGet()
        {
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject <List<Product>>(cartJson);
               
                SaveCartToTempData();

            }
            if (TempData.TryGetValue("SerializedUser", out var serializedUser) && serializedUser is string userJson)
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
                UserId = user.Id;
                var SerializedUser = JsonConvert.SerializeObject(user);
                TempData["SerializedUser"] = SerializedUser;
            }

            totalPrice = (products.Sum(p => p.Price)).ToString();
            

            
            

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
                totalPrice = (products.Sum(p => p.Price)).ToString();
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
                if (TempData.TryGetValue("SerializedUser", out var serializedUser) && serializedUser is string userJson)
                {
                    User user = JsonConvert.DeserializeObject<User>(userJson);
                    UserId = user.Id;
                }
                LoadCartFromTempData();
                List<string> productNames = new List<string>();
                totalPrice = (products.Sum(p => p.Price)).ToString();
                foreach (Product product in products)
                {
                    productNames.Add(product.Name);
                    
                }
                Payment payment = new Payment(Id, UserId, totalPrice, productNames);
                var AddedPayment = PS.AddPayment(payment);
                
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
