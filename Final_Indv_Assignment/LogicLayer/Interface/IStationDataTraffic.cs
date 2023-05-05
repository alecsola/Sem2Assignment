using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public interface IStationDataTraffic
    {
        bool AddStation(Station station);
        List<Station> GetAllStations();
        Station GetStationById(int id);
    }
}