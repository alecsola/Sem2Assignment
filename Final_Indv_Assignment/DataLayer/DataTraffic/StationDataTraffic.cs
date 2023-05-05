using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;
using DataLayer.DataConvertingToObject;
using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public class StationDataTraffic : DataHandler, IStationDataTraffic
    {
        protected override string cmd
        {
            get
            {
                return "select * from Station";
            }
        }

        public Station GetStationById(int id)
        {
            DataTable table = base.ReadData();
            foreach (DataRow dr in table.Rows)
            {
                Station station = DataConvertingStations.ConvertRowToStation(dr);
                if (station.Id == id)
                {
                    return station;
                }
            }
            return null; // or throw an exception indicating the ticket was not found
        }
        public List<Station> GetAllStations()
        {
            List<Station> stations = new List<Station>();
            DataTable table = base.ReadData();
            foreach (DataRow dr in table.Rows)
            {
                stations.Add(DataConvertingStations.ConvertRowToStation(dr));
            }


            return stations;
        }
        public bool AddStation(Station station)
        {
            string query = $"INSERT INTO Station (StationName, Latitude, Longitude)  " + $"VALUES '{station.Name}',{station.Latitude},{station.Longitude} ";
            return executeQuery(query) == 0 ? false : true;
        }
    }
}
