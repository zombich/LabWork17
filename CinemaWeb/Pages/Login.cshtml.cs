using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaWeb.Contexts;
using CinemaWeb.Models;
using AuthLibrary;
using Microsoft.EntityFrameworkCore;

namespace CinemaWeb.Pages
{
    public class LoginModel : PageModel
    {
        private readonly CinemaWeb.Contexts.CinemaDbContext _context;

        public LoginModel(CinemaWeb.Contexts.CinemaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CinemaUser CinemaUser { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CinemaUsers.Add(CinemaUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            var user = _context.CinemaUsers
                 .Include(u=> u.Role)
                 .FirstOrDefault(u => u.Login == CinemaUser.Login);

            CinemaUser.PasswordHash = AuthService.HashPassword(CinemaUser.PasswordHash);

            if (user is null || AuthService.VerifyPassword(user.PasswordHash, CinemaUser.PasswordHash))
                return Page();

            HttpContext.Session.SetString("Role", user.Role.Name);
            HttpContext.Session.SetString("Login", user.Login);

            return RedirectToPage("/Films/Index");
        }

        public async Task<IActionResult> OnPostGuestAsync()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("Role", "Гость");
            return RedirectToPage("/Films/Index");
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return Page();
        }
    }
}
