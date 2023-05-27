using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class Station
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
     
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Station(int id, string name, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public double CalculateDistance(Station destinationStation)
        {
            const double earthRadius = 6371; // in kilometers
            double dLat = ToRadians(destinationStation.Latitude - Latitude);
            double dLon = ToRadians(destinationStation.Longitude - Longitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(Latitude)) * Math.Cos(ToRadians(destinationStation.Latitude)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = earthRadius * c;
            return Math.Round(distance, 2);
        }

        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
