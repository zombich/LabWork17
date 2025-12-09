using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaWeb.Contexts;
using CinemaWeb.Models;

namespace CinemaWeb.Pages.Visitors
{
    public class IndexModel : PageModel
    {
        private readonly CinemaWeb.Contexts.CinemaDbContext _context;

        public IndexModel(CinemaWeb.Contexts.CinemaDbContext context)
        {
            _context = context;
        }

        public IList<Visitor> Visitor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Visitor = await _context.Visitors.ToListAsync();
        }
    }
}
