using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Class
{
    public class Ticket
    { 
        public int Id { get; set; }  
        public Station StartingStation { get; set; }
        public Station DestinationStation { get; set; }
        public string DepartureDate { get; set; }
        public string? ReturnDate { get; set; } // Nullable DateTime
        public double Distance { get; set; }
        public decimal Price { get; set; }
        public string Time { get; set; }

        public Ticket(int id,Station startingStation, Station destinationStation, string departureDate, string time)
        {

            Id= id;
            StartingStation = startingStation;
            DestinationStation = destinationStation;
            DepartureDate = departureDate;
            Time = time;
            
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
