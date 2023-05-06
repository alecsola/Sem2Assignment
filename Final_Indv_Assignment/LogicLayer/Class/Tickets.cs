using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class Tickets
    { 
       
        public Station StartingStation { get; set; }
        public Station DestinationStation { get; set; }
        public double Distance { get; set; }
        public decimal Price { get; set; }

        public Tickets(Station startingStation, Station destinationStation)
        {

           
            StartingStation = startingStation;
            DestinationStation = destinationStation;
            Distance = StartingStation.CalculateDistance(destinationStation, startingStation);
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            const decimal basePrice = 2.50m; // Base price for the ticket
            const decimal pricePerKm = 0.10m; // Price per kilometer

            decimal distanceInKm = (decimal)Distance; 
            decimal price = basePrice + (distanceInKm * pricePerKm); // Calculate ticket price

            Price = Math.Round(price, 2); // Round the price to two decimal places
        }
    }
}
