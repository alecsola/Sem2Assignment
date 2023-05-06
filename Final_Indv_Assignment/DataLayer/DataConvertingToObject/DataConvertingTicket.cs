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
            int startingStationId = (int)row["StartingStationId"];
            int destinationStationId = (int)row["DestinationStationId"];
            DateTime departureDate = (DateTime)row["DepartureDate"];

            // Use the StationDataTraffic class to get the starting and destination stations
            StationDataTraffic stationData = new StationDataTraffic();
            Station startingStation = stationData.GetStationById(startingStationId);
            Station destinationStation = stationData.GetStationById(destinationStationId);

            Ticket ticket = new Ticket(startingStation, destinationStation, departureDate);
            return ticket;



        }

    }
}
