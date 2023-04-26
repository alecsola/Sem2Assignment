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
    }
}
