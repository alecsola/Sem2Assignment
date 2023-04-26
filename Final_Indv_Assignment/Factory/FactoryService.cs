using DataLayer.DataTraffic;
using LogicLayer.Interface;
using LogicLayer.Services;


namespace Factory
{
    public class FactoryService
    {
        public static LogInService logIn { get; } = new LogInService(new UserDataTraffic());
        public static SeasonTicketsService seasonTickets = new SeasonTicketsService(new SeasonTicketDataTraffic());

        public static LogInService createlogInUser()
        {
            return new LogInService(new UserDataTraffic());
        }
        public static SeasonTicketsService createseasonTickets()
        {
            return new SeasonTicketsService(new SeasonTicketDataTraffic());
        }
    }
}