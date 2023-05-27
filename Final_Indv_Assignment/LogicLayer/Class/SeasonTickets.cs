using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class SeasonTickets
    {

        public int Id { get; private set; }
        public string SeasonTicketName { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }

        public string Image { get; private set; }

    

      
        public SeasonTickets(int id,string seasonTicketName, decimal price, string description, string image )
        {
            Id = id;
            SeasonTicketName = seasonTicketName;
            Price = price;
            Description = description;
            Image = image;
        }



    }
}
