using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaWeb.Contexts;
using CinemaWeb.Models;

namespace CinemaWeb.Pages.Visitors
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
            return Page();
        }

        [BindProperty]
        public Visitor Visitor { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Visitors.Add(Visitor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
