using Factory;
using LogicLayer.Class;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Indv_Assignment.Pages.Forms
{
    public class SeasonTicketsModel : PageModel
    {
       
        private SeasonTicketsService seasonTicketsService;
        SeasonTicketsService STS = FactoryService.createseasonTickets();
        //SeasonTickets seasonTickets = new List<SeasonTickets>();

       

        private readonly ILogger<IndexModel> _logger;

        public SeasonTicketsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
            //Tickets.Add(new Ticket() { price = 700 });
            //Tickets.Add(new Ticket() { name = "Premium Ticket" });


        }
        public List<SeasonTickets> seasonTickets
        {
            get { return STS.GetAllSeasonTickets(); }
        }
    }
}