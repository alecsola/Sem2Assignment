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
                return "SELECT t.Id,t.DepartureDate,t.Time, t.StartingStationId  AS startingId, s1.StationName AS StartingStation, t.DestinationStationId AS destinationId ,s2.StationName AS DestinationStation FROM Ticket t INNER JOIN Station s1 ON t.StartingStationId = s1.StationID INNER JOIN Station s2 ON t.DestinationStationId = s2.StationID;";
            }
        }

        public Ticket GetTicketById(int id)
        {
            DataTable table = base.ReadData(cmd);
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
            DataTable table = base.ReadData(cmd);
            foreach (DataRow dr in table.Rows)
            {
                tickets.Add(DataConvertingTicket.ConvertRowToTickets(dr));
            }


            return tickets;
        }
        public bool AddTicket(Ticket ticket)
        {
            
            string query = $"INSERT INTO Ticket (StartingStationId, DestinationStationId, DepartureDate, Time)  " + $"VALUES ({ticket.StartingStation.Id},{ticket.DestinationStation.Id},'{ticket.DepartureDate}','{ticket.Time}') ";
            return executeQuery(query) == 0 ? false : true;
        }
        public bool UpdateTicket(int Id, Station startingStation, Station destinationStation, string departureDate, string Time)
        {
            string query = $"UPDATE Ticket SET StartingStationId={startingStation.Id},DestinationStationId={destinationStation.Id},DepartureDate='{departureDate}', Time='{Time}' WHERE Id={Id}";
            return executeQuery(query) == 0 ? false : true;
        }
        public bool RemoveTicket(int Id)
        {
            string query = $"DELETE FROM Ticket WHERE Id = {Id}";
            return executeQuery(query) == 0 ? false : true;
        }
        public bool RemoveTicketByStation(Station station)
        {
            string query = $"DELETE FROM Ticket WHERE StartingStationId = {station.Id} or DestinationStationId={station.Id}";
            return executeQuery(query) == 0 ? false : true;
        }
        public List<Payment> HasUserSeasonTicket(int UserId)
        {
            List<Payment> payments = new List<Payment>();
            string query = $"SELECT p.Id, p.Price, p.UserId, p.ProductName FROM Payment p WHERE (p.ProductName='Month Ticket' OR p.ProductName='Gold Ticket' OR p.ProductName='Premium Ticket' OR p.ProductName='Child Ticket' OR p.ProductName='Young Ticket') AND p.UserId ={UserId} ;";
            DataTable table = base.ReadData(query);
            foreach (DataRow dr in table.Rows)
            {
                payments.Add(DataConvertingPayment.ConvertRowToPayment(dr));
            }

            return payments;
        }
        public List<Ticket> GetFilteredTickets(Station startingStation, Station endingStation, string departureDate,string?Time)
        {
            List<Ticket> filteredTickets = new List<Ticket>();
            if (Time != null)
            {
                string query = $"SELECT t.Id, t.DepartureDate, t.Time, t.StartingStationId AS startingId, s1.StationName AS StartingStation, t.DestinationStationId AS destinationId, s2.StationName AS DestinationStation \r\nFROM Ticket t INNER JOIN Station s1 \r\n\tON t.StartingStationId = s1.StationID \r\n\t\tINNER JOIN Station s2\r\n\t\tON t.DestinationStationId = s2.StationID\r\nWHERE t.StartingStationId={startingStation.Id} and t.DestinationStationId={endingStation.Id} and DepartureDate='{departureDate}' and t.Time = '{Time}';";
                DataTable table = base.ReadData(query);
                foreach (DataRow dr in table.Rows)
                {
                    filteredTickets.Add(DataConvertingTicket.ConvertRowToTickets(dr));
                }
            }
            else
            {
                string query = $"SELECT t.Id, t.DepartureDate, t.Time, t.StartingStationId AS startingId, s1.StationName AS StartingStation, t.DestinationStationId AS destinationId, s2.StationName AS DestinationStation \r\nFROM Ticket t INNER JOIN Station s1 \r\n\tON t.StartingStationId = s1.StationID \r\n\t\tINNER JOIN Station s2\r\n\t\tON t.DestinationStationId = s2.StationID\r\nWHERE t.StartingStationId={startingStation.Id} and t.DestinationStationId={endingStation.Id} and DepartureDate='{departureDate}';";
                DataTable table = base.ReadData(query);
                foreach (DataRow dr in table.Rows)
                {
                    filteredTickets.Add(DataConvertingTicket.ConvertRowToTickets(dr));
                }
            }
           
            
            return filteredTickets;
        }


    }
}
