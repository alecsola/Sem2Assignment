using DataLayer.DataTraffic;
using LogicLayer.Class;
using LogicLayer.Services;
using Moq;

namespace TestProject1

{

    [TestClass]
    public class SeasonTicketServiceTest
    {

        public SeasonTicketServiceTest()
        {

        }

        [TestMethod]
        public void TestGetAllSeasonTickets()
        {
            // Arrange
            var mockDataTraffic = new Mock<ISeasonTicketDataTraffic>();
            var expectedTickets = new List<SeasonTickets>
        {
            new SeasonTickets ( "A", 1,"A","A" ),
            new SeasonTickets ( "B", 1,"B","B" ),
            new SeasonTickets ( "C", 1,"C","C" )
        };
            mockDataTraffic.Setup(x => x.GetAllSeasonTickets()).Returns(expectedTickets);
            var logic = new SeasonTicketsService(mockDataTraffic.Object);

            // Act
            var result = logic.GetAllSeasonTickets();

            // Assert
            Assert.AreEqual(expectedTickets, result);
        }
    }
}

//public class SeasonTicketsServiceTests
//{
//    private ISeasonTicketDataTraffic _mockSeasonTicketDataTraffic;
//    private SeasonTicketsService _seasonTicketService;

//    [SetUp]
//    public void Setup()
//    {
//        // Create a mock of the ISeasonTicketDataTraffic interface using a mocking framework such as Moq
//        _mockSeasonTicketDataTraffic = Mock.Of<ISeasonTicketDataTraffic>();
//        _seasonTicketService = new SeasonTicketsService(_mockSeasonTicketDataTraffic);
//    }

//    [Test]
//    public void GetSeasonTicketById_ReturnsTicket_WhenTicketExists()
//    {
//        // Arrange
//        var expectedTicket = new SeasonTickets { Id = 1, Name = "Test Ticket" };
//        Mock.Get(_mockSeasonTicketDataTraffic)
//            .Setup(m => m.GetSeasonTicketById(1))
//            .Returns(expectedTicket);

//        // Act
//        var result = _seasonTicketService.GetSeasonTicketById(1);

//        // Assert
//        Assert.AreEqual(expectedTicket, result);
//    }

//    [Test]
//    public void GetSeasonTicketById_ReturnsNull_WhenTicketDoesNotExist()
//    {
//        // Arrange
//        Mock.Get(_mockSeasonTicketDataTraffic)
//            .Setup(m => m.GetSeasonTicketById(2))
//            .Returns((SeasonTickets)null);

//        // Act
//        var result = _seasonTicketService.GetSeasonTicketById(2);

//        // Assert
//        Assert.IsNull(result);
//    }
