using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebugWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DebugWebApp.Pages
{
    public class IndexModel : PageModel
    {

        public Ticket Ticket { get; set; }

        public IndexModel()
        {
            
        }

        public void OnGet()
        {
            var newTicket = new Ticket();
            newTicket.BasePrice = 200.0m;
            newTicket.PremiumFee = 25.0m;
            newTicket.IsPremium = false;

            Ticket = newTicket;
        }
    }
}
