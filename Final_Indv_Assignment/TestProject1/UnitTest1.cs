using DataLayer.DataTraffic;
using LogicLayer.Class;
using LogicLayer.Services;

namespace TestProject1

{
    
    [TestClass]
    public class SeasonTicketServiceTest
    {


        
        [TestMethod]
        public void GetAllSeasonTickets()
        {
            

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
}