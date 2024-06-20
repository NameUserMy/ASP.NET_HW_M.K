using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Top_10_films.Models;

namespace Top_10_films.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext? _db;
        public MoviesController(MovieContext context) {
        
            _db = context;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.CardMovies.ToListAsync());
        }
    }
}
