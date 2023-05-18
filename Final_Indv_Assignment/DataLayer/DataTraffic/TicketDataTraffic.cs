using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;
using DataLayer.DataConvertingToObject;
using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public class TicketDataTraffic: DataHandler ,ITicketDataTraffic
    {
        protected override string cmd
        {
            get
            {
                return "SELECT t.DepartureDate, t.StartingStationId  AS startingId, s1.StationName AS StartingStation, t.DestinationStationId AS destinationId ,s2.StationName AS DestinationStation FROM Ticket t INNER JOIN Station s1 ON t.StartingStationId = s1.StationID INNER JOIN Station s2 ON t.DestinationStationId = s2.StationID;";
            }
        }

        public Ticket GetTicketById(int id)
        {
            DataTable table = base.ReadData();
            foreach (DataRow dr in table.Rows)
            {
                Ticket ticket = DataConvertingTicket.ConvertRowToTickets(dr);
                if (ticket.Id == id)
                {
                    return ticket;
                }
            }
            return null; // or throw an exception indicating the ticket was not found
        }

        public List<Ticket> GetAllTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            DataTable table = base.ReadData();
            foreach (DataRow dr in table.Rows)
            {
                tickets.Add(DataConvertingTicket.ConvertRowToTickets(dr));
            }


            return tickets;
        }
        public bool AddTicket(Ticket ticket)
        {
            string query = $"INSERT INTO Ticket (StartingStationId, DestinationStationId, DepartureDate)  " + $"VALUES '{ticket.StartingStation}',{ticket.DestinationStation},{ticket.DestinationStation} ";
            return executeQuery(query) == 0 ? false : true;
        }

        public List<Ticket> GetFilteredTickets(Station startingStation, Station endingStation, string departureDate)
        {
            List<Ticket> filteredTickets = new List<Ticket>();
            DataTable table = base.ReadData();
            foreach (DataRow dr in table.Rows)
            {
                Ticket ticket = DataConvertingTicket.ConvertRowToTickets(dr);
               
                    if (ticket.StartingStation == startingStation &&
                        ticket.DestinationStation == endingStation &&
                        ticket.DepartureDate == departureDate )
                    {
                        filteredTickets.Add(ticket);
                    }             
            }
            return filteredTickets;
        }


    }
}
