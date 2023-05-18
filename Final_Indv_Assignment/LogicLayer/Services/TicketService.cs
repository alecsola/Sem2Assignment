using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataTraffic;
using LogicLayer.Class;

namespace LogicLayer.Services
{
    public class TicketService
    {

        private ITicketDataTraffic ticketDataTraffic;


        public TicketService(ITicketDataTraffic ticketDataTraffic)
        {
            this.ticketDataTraffic = ticketDataTraffic ?? throw new ArgumentNullException(nameof(ticketDataTraffic));
        }
        public List<Ticket> GetAllTickets()
        {
            return ticketDataTraffic.GetAllTickets();
        }
        public bool AddTicket(Ticket ticket)
        {
            return ticketDataTraffic.AddTicket(ticket);
        }
        public Ticket GetTicketById(int id)
        {
            return ticketDataTraffic.GetTicketById(id);
        }
        public List<Ticket> GetAllTicketsByDepartureDate(Station startingStation, Station destinationStation, string departureDate)
        {
            List<Ticket> filteredTickets = new List<Ticket>();
            foreach (Ticket ticket in GetAllTickets())
            {
                if( ticket.StartingStation.Name == startingStation.Name
                                  && ticket.DestinationStation.Name == destinationStation.Name
                                  && ticket.DepartureDate == departureDate)
                {
                    filteredTickets.Add(ticket);
                }
            }
            return filteredTickets;
        }

    }
}
