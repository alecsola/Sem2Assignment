using LogicLayer.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Indv_Assignment.Pages.Forms
{
    public class TicketsModel : PageModel
    {
        public List<Ticket> Tickets { get; set; }

        public void OnGet(List<Ticket> tickets)
        {
            Tickets = tickets;
            // Use the Tickets list as needed
        }
    }
}
