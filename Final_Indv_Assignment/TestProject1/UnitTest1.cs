using DataLayer.DataTraffic;
using LogicLayer.Class;
using LogicLayer.Services;
using Moq;

namespace TestProject1

{

    [TestClass]
    public class SeasonTicketServiceTest
    {



        [TestMethod]
        public void TestGetAllSeasonTickets()
        {
            // Arrange
            var mockDataTraffic = new Mock<ISeasonTicketDataTraffic>();
            var expectedTickets = new List<SeasonTickets>
        {
            new SeasonTickets (1, "A", 1,"A","A" ),
            new SeasonTickets ( 1,"B", 1,"B","B" ),
            new SeasonTickets (1, "C", 1,"C","C" )
        };
            mockDataTraffic.Setup(x => x.GetAllSeasonTickets()).Returns(expectedTickets);
            var logic = new SeasonTicketsService(mockDataTraffic.Object);

            // Act
            var result = logic.GetAllSeasonTickets();

            // Assert
            Assert.AreEqual(expectedTickets, result);
        }
        [TestMethod]
        public void CalculateDistance()
        {
            // Arrange
            Station station1 = new Station(1, "Station A", 0, 0);
            Station station2 = new Station(2, "Station B", 0.1, 0.1);

            // Act
            double distance = station1.CalculateDistance(station2);

            // Assert
            double expectedDistance = 15.73; 
            double delta = 1.0; // Adjust the delta value as needed
            Assert.AreEqual(expectedDistance, distance, delta);
        }
        [TestMethod]
        public void CalculatePrice()
        {
            // Arrange
            Station startingStation = new Station(1, "Station A", 0, 0);
            Station destinationStation = new Station(2, "Station B", 0.1, 0.1);
            Ticket ticket = new Ticket(1, startingStation, destinationStation, "2023-06-06", "12:00");

            // Act
            decimal price = ticket.CalculatePrice();
            decimal distanceInKm = (decimal)ticket.Distance;
            decimal expectedPrice = 2.50m + (distanceInKm * 0.30m);
            expectedPrice = Math.Round(expectedPrice, 2);
            // Assert
            Assert.AreEqual(expectedPrice, price);
        }
       

    }
}

