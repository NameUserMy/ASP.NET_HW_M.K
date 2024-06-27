using HW_4_Top_10_CRUD.Data;
using HW_4_Top_10_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace HW_4_Top_10_CRUD.Controllers
{
    public class AddController : Controller
    {
        private readonly ILogger<HomeController>? _logger;
        private TenMoviesContext? _db;
        private IWebHostEnvironment? _environment;
        private string? pathSave;

        public AddController (TenMoviesContext contex,IWebHostEnvironment path, ILogger<HomeController> logger) {
        
            _db = contex;
            _environment = path;
            _logger = logger;
        
        }
       
        public IActionResult AddMovies()
        {
            return View();
        }


        [HttpPost]
        [RequestSizeLimit(1000000)]
        [ValidateAntiForgeryToken]//Chek control sum;
        public async Task<IActionResult> AddMovies(
            [Bind("Title,Description,Genre,Year,PosterUrl,Runtime,Director,Actors,Language")] AllInfoModelView movie,IFormFile? uploadPoster) {
            if (uploadPoster is not null)
            {
                pathSave = "/imgSrc/posters/" + uploadPoster.FileName;

                using (var fileStream = new FileStream(_environment.WebRootPath + pathSave, FileMode.Create))
                {

                    await uploadPoster.CopyToAsync(fileStream);

                }

            }

           

            movie.PosterUrl = pathSave;
            if (movie.Genre=="Genre")
            {
                ModelState.AddModelError("", "Enter normal  Genre");

            }
            if (movie.Title == "Title")
            {
                ModelState.AddModelError("", "Enter normal  Title");

            }

            if (ModelState.IsValid)
            {


                _db.AddAsync(new Movie
                {

                    Title = movie.Title,
                    Genre = movie.Genre,
                    PosterUrl = movie.PosterUrl,
                    Description = movie.Description,
                    Director = movie.Director,
                    Year = movie.Year,
                    Runtime = movie.Runtime,
                    Actors = movie.Actors,
                    Language = movie.Language
                });
                _db.SaveChangesAsync();
                return RedirectToAction("AddMovies");
            }
           
                return View(movie);
            
           
            
        }
    }
}
