using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public interface IStationDataTraffic
    {
        bool AddStation(Station station);
        List<Station> GetAllStations();
        Station GetStationById(int id);
        bool UpdateStation(int Id,string Name, decimal Latitude, decimal Longitude);
        bool RemoveStation(int Id);
    }
}