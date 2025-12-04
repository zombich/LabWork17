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
    public class IndexModel : AuthPageModel
    {
        private readonly CinemaWeb.Contexts.CinemaDbContext _context;

        public IndexModel(CinemaWeb.Contexts.CinemaDbContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!IsAdmin)
            if (IsInRole("Билетер") is IActionResult action)
                return action;
            

                Ticket = await _context.Tickets
                    .Include(t => t.Session)
                    .Include(t => t.Visitor).ToListAsync();
            return Page();
        }
    }
}
