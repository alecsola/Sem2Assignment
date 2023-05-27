using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class Cart
    {
        public int UserId { get; private set; }
        public List<Product> Products { get; set; }
        

        public Cart( )
        {
            Products = new List<Product>();
        }
    }
}
