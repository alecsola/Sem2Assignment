using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public interface ITicketDataTraffic
    {
        bool AddTicket(Ticket ticket);
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        List<Ticket> GetFilteredTickets(Station startingStation, Station endingStation, string departureDate);
    }
}