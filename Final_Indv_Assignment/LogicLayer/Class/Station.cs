using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        

        public double CalculateDistance(Station destinationStation, Station startingDestination)
        {
            const double earthRadius = 6371; // in kilometers
            double dLat = ToRadians(destinationStation.Latitude - startingDestination.Latitude);
            double dLon = ToRadians(destinationStation.Longitude - startingDestination.Longitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(startingDestination.Latitude)) * Math.Cos(ToRadians(destinationStation.Latitude)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = earthRadius * c;
            return distance;
        }

        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
