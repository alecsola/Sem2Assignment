using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class Ticket
    { 
        public int Id { get; private set; }  
        public Station StartingStation { get; private set; }
        public Station DestinationStation { get; private set; }
        public string DepartureDate { get; private set; }
        public string? ReturnDate { get; private set; } // Nullable DateTime
        public double Distance { get; private set; }
        public decimal Price { get; private set; }
        public string Time { get; private set; }



        public Ticket(int id,Station startingStation, Station destinationStation, string departureDate, string time)
        {

            Id= id;
            StartingStation = startingStation;
            DestinationStation = destinationStation;
            DepartureDate = departureDate;
            Time = time;
            
            Distance = StartingStation.CalculateDistance(destinationStation);
            Price = CalculatePrice();
        }

        private decimal CalculatePrice()
        {
            const decimal basePrice = 2.50m; // Base price for the ticket
            const decimal pricePerKm = 0.30m; // Price per kilometer

            decimal distanceInKm = (decimal)Distance; 
            decimal price = basePrice + (distanceInKm * pricePerKm); // Calculate ticket price

            return Math.Round(price, 2); // Round the price to two decimal places
        }
    }
}
