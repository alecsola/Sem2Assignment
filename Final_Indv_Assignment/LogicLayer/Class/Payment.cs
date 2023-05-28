using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class Payment
    {
        public int Id { get;private set; }
        public int UserId { get; private set; }
     
        public string Price { get; private set; }
        public List<string> ProductName { get; private set; }
        
        

        public Payment(int id, int userId,string price, List<string> productName )
        {
            Id = id++;
            UserId = userId;
            Price = price;
            ProductName = productName;
        }
    }
}
