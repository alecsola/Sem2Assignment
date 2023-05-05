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
            SeasonTickets seasonTickets = new SeasonTickets("", "", "","");

            seasonTickets.SeasonTicketName = (string)row["SeasonTicketName"];
            seasonTickets.Price = (string)row["Price"];
            seasonTickets.Description = (string)row["SeasonTicketDescription"];
            seasonTickets.Image = (string)row["ImageURL"];

            return seasonTickets;
            
        }
    }
}
