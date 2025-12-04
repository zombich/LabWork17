using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaWeb.Contexts;
using CinemaWeb.Models;

namespace CinemaWeb.Pages.Tickets
{
    public class DetailsModel : AuthPageModel
    {
        private readonly CinemaWeb.Contexts.CinemaDbContext _context;

        public DetailsModel(CinemaWeb.Contexts.CinemaDbContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (IsInRole("Билетер") is IActionResult action)
                return action;

            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.TicketId == id);

            if (ticket is not null)
            {
                Ticket = ticket;

                return Page();
            }

            return NotFound();
        }
    }
}
