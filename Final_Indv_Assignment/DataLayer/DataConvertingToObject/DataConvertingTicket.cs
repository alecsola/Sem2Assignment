using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataTraffic;
using LogicLayer.Class;
using static System.Collections.Specialized.BitVector32;

namespace DataLayer.DataConvertingToObject
{
    public class DataConvertingTicket
    {
        public static Ticket ConvertRowToTickets(DataRow row)
        {
            int startingStationId = (int)row["startingId"];
            int destinationStationId = (int)row["destinationId"];
            string departureDate = ((DateTime)row["DepartureDate"]).ToString("yyyy-MM-dd");
            string time = ((TimeSpan)row["Time"]).ToString("hh\\:mm");
            int id = (int)row["Id"];

            // Use the StationDataTraffic class to get the starting and destination stations
            StationDataTraffic stationData = new StationDataTraffic();
            Station startingStation = stationData.GetStationById(startingStationId);
            Station destinationStation = stationData.GetStationById(destinationStationId);

            Ticket ticket = new Ticket(id,startingStation, destinationStation, departureDate, time);
            return ticket;



        }

    }
}
