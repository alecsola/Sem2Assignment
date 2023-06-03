using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public interface ISeasonTicketDataTraffic
    {
       
        SeasonTickets GetSeasonTicketById(int id);
        List<SeasonTickets> GetAllSeasonTickets();
        bool AddSeasonTicket(SeasonTickets seasonTicket);
        bool UpdateSeasonTicket(int Id, string Name, decimal Price, string Description, string Image);
        bool RemoveSeasonTicket(int Id);

    }
}