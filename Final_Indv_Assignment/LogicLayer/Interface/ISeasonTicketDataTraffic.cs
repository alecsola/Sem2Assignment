using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public interface ISeasonTicketDataTraffic
    {
       
        SeasonTickets GetSeasonTicketById(int id);
        List<SeasonTickets> GetAllSeasonTickets();
    }
}