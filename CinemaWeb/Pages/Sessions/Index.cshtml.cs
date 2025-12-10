using CinemaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CinemaWeb.Pages.Sessions
{
    public class IndexModel : PageModel
    {
        private readonly CinemaWeb.Contexts.CinemaDbContext _context;

        [BindProperty(SupportsGet = true)]
        public string FilmTitle { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortColumn { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Hall { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; } = 3;

        public IndexModel(CinemaWeb.Contexts.CinemaDbContext context)
        {
            _context = context;
        }

        public IList<Session> Session { get; set; } = default!;

        public async Task OnGetAsync()
        {
            ViewData["Halls"] = new SelectList(_context.Halls, "HallId", "HallInfo");

            var sessions = _context.Sessions
                    .Include(s => s.Film)
                    .Include(s => s.Hall)
                    .AsQueryable();

            if (!FilmTitle.IsNullOrEmpty())
                sessions = sessions
                    .Where(s => s.Film.Name.Contains(FilmTitle));

            if (SortColumn is not null)
            {
                if (SortColumn == "price")
                    sessions = sessions
                        .OrderBy(s => s.Price);
                else if (SortColumn == "price_desc")
                    sessions = sessions
                        .OrderByDescending(s => s.Price);
            }

            if (Hall > 0)
                sessions = sessions
                    .Where(s => s.Hall.HallId == Hall);

            TotalPages = (int)Math.Ceiling(sessions.Count() / (double)PageSize);

            sessions = sessions
                .Take(PageSize * PageIndex)
                .Skip(PageSize * (PageIndex - 1));


            Session = await sessions
                    .ToListAsync();
        }
    }
}
