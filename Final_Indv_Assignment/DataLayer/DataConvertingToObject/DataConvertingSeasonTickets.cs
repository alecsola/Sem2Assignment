using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Class;

namespace DataLayer.DataConvertingToObject
{
    public class DataConvertingSeasonTickets
    {

        public static SeasonTickets ConvertRowToSeasonTickets(DataRow row)
        {
            
            int id = (int)row["SeasonTicketID"];
            string SeasonTicketName = (string)row["SeasonTicketName"];
            decimal Price = (decimal)row["Price"];
            string Description = (string)row["SeasonTicketDescription"];
            string Image = (string)row["ImageURL"];
            SeasonTickets seasonTickets = new SeasonTickets(id,SeasonTicketName,Price, Description,Image);

            return seasonTickets;
            
        }
    }
}
