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
    public class StationService
    {
        private IStationDataTraffic stationDataTraffic;
        
        
        public StationService (IStationDataTraffic stationDataTraffic)
        {
            this.stationDataTraffic = stationDataTraffic ?? throw new ArgumentNullException(nameof(stationDataTraffic));
        }
        public List<Station> GetAllStations()
        {
            return stationDataTraffic.GetAllStations();
        }
        public bool AddStation(Station station)
        {
            return stationDataTraffic.AddStation(station);
        }
        public bool UpdateStation(int Id, string Name, decimal Latitude, decimal Longitude)
        {
           return stationDataTraffic.UpdateStation(Id,Name, Latitude, Longitude);
        }
        public bool RemoveStation(int Id)
        {
            return stationDataTraffic.RemoveStation(Id);
        }
    }
    
}
