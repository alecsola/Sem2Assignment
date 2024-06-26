﻿using System;
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
        public bool UpdateTicket(int Id, Station startingStation, Station destinationStation, string departureDate, string Time)
        {
            return ticketDataTraffic.UpdateTicket(Id, startingStation, destinationStation, departureDate, Time);
        }
        public bool RemoveTicket(int Id)
        {
            return ticketDataTraffic.RemoveTicket(Id);
        }
        public bool RemoveTicketByStation(Station station)
        {
            return ticketDataTraffic.RemoveTicketByStation(station);
        }
        public Ticket GetTicketById(int id)
        {
            return ticketDataTraffic.GetTicketById(id);
        }
        public List<Ticket> GetFilteredTickets(Station startingStation, Station endingStation, string departureDate, string? Time)
        {
            return ticketDataTraffic.GetFilteredTickets(startingStation, endingStation, departureDate, Time);
        }

    }
}
