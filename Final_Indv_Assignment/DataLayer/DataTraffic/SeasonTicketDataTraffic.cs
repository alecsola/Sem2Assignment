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
using Microsoft.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

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
        public bool AddSeasonTicket(SeasonTickets seasonTicket)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Description", seasonTicket.Description));

            string query = $"INSERT INTO SeasonTickets (SeasonTicketName, Price,SeasonTicketDescription,ImageURL)  " + $"VALUES ('{seasonTicket.SeasonTicketName}',{seasonTicket.Price},@Description,'{seasonTicket.Image}') ";
            return executeQuery(query, parameters.ToArray()) == 0 ? false : true;
        }
        public bool UpdateSeasonTicket(int Id, string Name, decimal Price, string Description, string Image)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Description", Description));
            string query = $"UPDATE SeasonTickets SET SeasonTicketName='{Name}', Price={Price},SeasonTicketDescription=@Description, ImageURL='{Image}' WHERE SeasonTicketID={Id}";
            return executeQuery(query, parameters.ToArray()) == 0 ? false : true;
        }
        public bool RemoveSeasonTicket(int Id)
        {
            string query = $"DELETE FROM SeasonTickets WHERE SeasonTicketID = {Id}";
            return executeQuery(query) == 0 ? false : true;
        }


    }
}
