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
    }
    [TestClass]
    public class StationDistancePriceTest
    {

        

        [TestMethod]
        public List<Ticket> GetAllTicketsByDepartureDate(Station startingStation, Station destinationStation, string departureDate, string? time)
        {
            // Arrange
            var mockDataTraffic = new Mock<ITicketDataTraffic>();
            var expectedTickets = new List<Ticket>();
            startingStation = new Station
            {
                Name = "Amsterdam"
            };
            startingStation = new Station
            {
                Name = "Den Haag"
            };
            List<Ticket> filteredTickets = new List<Ticket>();
            {
                new Ticket(1, startingStation, destinationStation, "2023-05-06", "11:00");
            };
            mockDataTraffic.Setup(x => x.GetAllTickets()).Returns(expectedTickets);
            var logic = new TicketService(mockDataTraffic.Object);
            foreach (Ticket ticket in logic.GetAllTickets())
            {
                if (ticket.StartingStation.Name == startingStation.Name
                                  && ticket.DestinationStation.Name == destinationStation.Name
                                  && ticket.DepartureDate == departureDate
                                  && (time == null || ticket.Time == time))
                {
                    filteredTickets.Add(ticket);
                }
            }
            return filteredTickets;
            

            // Act
            var result = logic.GetAllTickets;

            // Assert
            Assert.AreEqual(expectedTickets, result);
        }
    }
}
