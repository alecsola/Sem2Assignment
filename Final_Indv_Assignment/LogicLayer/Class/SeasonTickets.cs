using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class SeasonTickets
    {

        public int Id { get; set; }
        public string SeasonTicketName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

    

      
        public SeasonTickets(string seasonTicketName, string price, string description, string image )
        {
            //Id = id;
            SeasonTicketName = seasonTicketName;
            Price = price;
            Description = description;
            Image = image;
        }


    }
}
