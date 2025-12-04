using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaWeb.Contexts;
using CinemaWeb.Models;

namespace CinemaWeb.Pages.Films
{
    public class CreateModel : AuthPageModel
    {
        private readonly CinemaWeb.Contexts.CinemaDbContext _context;

        public CreateModel(CinemaWeb.Contexts.CinemaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (CanEdit() is IActionResult action)
                return action;

            return Page();
        }

        [BindProperty]
        public Film Film { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Films.Add(Film);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
