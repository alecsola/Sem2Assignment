using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public interface ITicketDataTraffic
    {
        bool AddTicket(Ticket ticket);
        List<Ticket> GetAllStations();
        Ticket GetTicketById(int id);
    }
}