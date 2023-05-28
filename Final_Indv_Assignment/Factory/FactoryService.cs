using DataLayer.DataTraffic;
using LogicLayer.Interface;
using LogicLayer.Services;


namespace Factory
{
    public class FactoryService
    {
        //public static LogInService logIn { get; } = new LogInService(new UserDataTraffic());
        //public static SeasonTicketsService seasonTickets { get; } = new SeasonTicketsService(new SeasonTicketDataTraffic());
        //public static StationService station { get; } = new StationService(new StationDataTraffic());

        //public static TicketService ticket { get; } = new TicketService(new TicketDataTraffic());

        public static LogInService createlogInUser()
        {
            return new LogInService(new UserDataTraffic());
        }
        public static SeasonTicketsService createseasonTickets()
        {
            return new SeasonTicketsService(new SeasonTicketDataTraffic());
        }
        public static StationService createStation()
        {
            return new StationService(new StationDataTraffic());
        }
        public static TicketService createTicket()
        {
            return new TicketService(new TicketDataTraffic());
        }
        public static PaymentService createPayment()
        {
            return new PaymentService(new PaymentDataTraffic());
        }

    }
}