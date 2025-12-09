using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaWeb.Contexts;
using CinemaWeb.Models;

namespace CinemaWeb.Pages.Sessions
{
    public class CreateModel : PageModel
    {
        private readonly CinemaWeb.Contexts.CinemaDbContext _context;

        public CreateModel(CinemaWeb.Contexts.CinemaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FilmId"] = new SelectList(_context.Films, "FilmId", "Name");
        ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallInfo");
            return Page();
        }

        [BindProperty]
        public Session Session { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Session.Film");
            ModelState.Remove("Session.Hall");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sessions.Add(Session);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
