using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;
using DataLayer.DataConvertingToObject;
using LogicLayer.Class;
using LogicLayer.Interface;

namespace DataLayer.DataTraffic
{
    public class SeasonTicketDataTraffic : DataHandler, ISeasonTicketDataTraffic
    {
        protected override string cmd
        {
            get
            {
                return "select * from SeasonTickets";
            }
        }

        public SeasonTickets GetSeasonTicketById(int id)
        {
            DataTable table = base.ReadData(cmd);
            foreach (DataRow dr in table.Rows)
            {
                SeasonTickets ticket = DataConvertingSeasonTickets.ConvertRowToSeasonTickets(dr);
                if (ticket.Id == id)
                {
                    return ticket;
                }
            }
            return null; // or throw an exception indicating the ticket was not found
        }
        public List<SeasonTickets> GetAllSeasonTickets()
        {
            List<SeasonTickets> Tickets = new List<SeasonTickets>();
            DataTable table = base.ReadData(cmd);
            foreach (DataRow dr in table.Rows)
            {
                Tickets.Add(DataConvertingSeasonTickets.ConvertRowToSeasonTickets(dr));
            }


            return Tickets;
        }




    }
}
