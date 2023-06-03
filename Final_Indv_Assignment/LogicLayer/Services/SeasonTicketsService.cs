using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataTraffic;
using LogicLayer.Class;
using LogicLayer.Interface;

namespace LogicLayer.Services
{
    public class SeasonTicketsService : ISeasonTicketDataTraffic
    {
        private ISeasonTicketDataTraffic seasonTicketDataTraffic;
        public SeasonTicketsService(ISeasonTicketDataTraffic seasonTicketDataTraffic)
        {
            this.seasonTicketDataTraffic = seasonTicketDataTraffic
             ?? throw new ArgumentNullException(nameof(seasonTicketDataTraffic));
        }
        public SeasonTickets GetSeasonTicketById(int id)
        {
            return this.seasonTicketDataTraffic.GetSeasonTicketById(id);
        }
        public List<SeasonTickets> GetAllSeasonTickets()
        {
            return this.seasonTicketDataTraffic.GetAllSeasonTickets();
        }
        public bool AddSeasonTicket(SeasonTickets seasonTicket)
        {
            return this.seasonTicketDataTraffic.AddSeasonTicket(seasonTicket);
        }
        public bool UpdateSeasonTicket(int Id, string Name, decimal Price, string Description, string Image)
        {
            return this.seasonTicketDataTraffic.UpdateSeasonTicket(Id, Name, Price, Description, Image);
        }
        public bool RemoveSeasonTicket(int Id)
        {
            return this.seasonTicketDataTraffic.RemoveSeasonTicket(Id);
        }
    }
}
