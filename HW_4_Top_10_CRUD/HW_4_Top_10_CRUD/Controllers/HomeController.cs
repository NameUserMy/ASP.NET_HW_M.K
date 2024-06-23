using HW_4_Top_10_CRUD.Data;
using HW_4_Top_10_CRUD.Models;
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
        public async Task<IActionResult> Details(int id)
        {
            AllInfoModelView modelView = new AllInfoModelView();
           var src = await _context.Movies.Where(e => e.Id == id).FirstAsync();
           
            modelView.Title = src.Title;
            modelView.Description = src.Description;
            modelView.Actors = src.Actors;
            modelView.Director= src.Director;
            modelView.Genre= src.Genre;
            modelView.Language = src.Language;
            modelView.PosterUrl = src.PosterUrl;
            modelView.Year = src.Year;
            modelView.Runtime = src.Runtime;
            return PartialView("Details", modelView);
        }


        public async Task<IActionResult> Delete(int id)
        {
            _context.Movies.Remove(await _context.Movies.FirstOrDefaultAsync(e => e.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
