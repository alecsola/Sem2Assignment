using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;
using DataLayer.DataConvertingToObject;
using LogicLayer.Class;
using Microsoft.Data.SqlClient;

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
            DataTable table = base.ReadData(cmd);
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
            DataTable table = base.ReadData(cmd);
            foreach (DataRow dr in table.Rows)
            {
                stations.Add(DataConvertingStations.ConvertRowToStation(dr));
            }


            return stations;
        }
        public bool AddStation(Station station)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Latitude", station.Latitude));
            parameters.Add(new SqlParameter("Longitude", station.Longitude));
            string query = $"INSERT INTO Station (StationName, Latitude, Longitude)  " + $"VALUES ('{station.Name}',@Latitude,@Longitude) ";
            return executeQuery(query, parameters.ToArray()) == 0 ? false : true;
        }
        public bool UpdateStation(int Id, string Name, decimal Latitude, decimal Longitude)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Name", Name));
            parameters.Add(new SqlParameter("Latitude", Latitude));
            parameters.Add(new SqlParameter("Longitude", Longitude));
            string query = $"UPDATE Station SET StationName=@Name, Latitude=@Latitude,Longitude=@Longitude WHERE StationID={Id}";
            return executeQuery(query, parameters.ToArray()) == 0 ? false : true;
        }
        public bool RemoveStation(int Id)
        {
            string query = $"DELETE FROM Station WHERE StationID = {Id}";
            return executeQuery(query) == 0 ? false : true;
        }

    }
}
