using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public interface ITicketDataTraffic
    {
        bool AddTicket(Ticket ticket);
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        bool RemoveTicket(int Id);
        bool RemoveTicketByStation(Station station);
        bool UpdateTicket(int Id, Station startingStation, Station destinationStation, string departureDate, string Time);
        List<Ticket> GetFilteredTickets(Station startingStation, Station endingStation, string departureDate, string? Time);
    }
}