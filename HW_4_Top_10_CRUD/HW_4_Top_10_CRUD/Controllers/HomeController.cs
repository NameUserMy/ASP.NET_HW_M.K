using HW_4_Top_10_CRUD.Data;
using Microsoft.AspNetCore.Mvc;
//using HW_4_Top_10_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace HW_4_Top_10_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private TenMoviesContext? _context;
        public HomeController(TenMoviesContext contex) { 
       
            _context = contex;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }
    }
}
