using LogicLayer.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Final_Indv_Assignment.Pages.Forms
{
    public class CartModel : PageModel
    {
        [BindProperty]
        public List<Product>products { get; set; }

        public void OnGet()
        {
            if (TempData.TryGetValue("SerializedCart", out var serializedCart) && serializedCart is string cartJson)
            {
                products = JsonConvert.DeserializeObject <List<Product>>(cartJson);
                var SerializedCart = JsonConvert.SerializeObject(products);
                TempData["SerializedCart"] = SerializedCart;

            }
            
        }
        
    }
}
