using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaWeb.Pages
{
    public class AuthPageModel : PageModel
    {
        public string UserRole => HttpContext.Session.GetString("Role");
        public bool IsAdmin => UserRole == "Администратор";

        protected IActionResult HasRole()
        {
            if (string.IsNullOrEmpty(UserRole))
                return RedirectToPage("/Login");
            return null;
        }
        protected IActionResult IsInRole(string role)
        {
            if (string.IsNullOrEmpty(UserRole))
                return RedirectToPage("/Login");

            if (role == UserRole)
                return null;

            return RedirectToPage("./Index");
        }
        protected IActionResult CanEdit()
        {
            if (string.IsNullOrEmpty(UserRole))
                return RedirectToPage("/Login");

            if (IsAdmin)
                return null;

            return RedirectToPage("./Index");
        }
    }
}
