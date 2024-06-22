using HW_4_Top_10_CRUD.Data;
using HW_4_Top_10_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_4_Top_10_CRUD.Controllers
{
    public class AddController : Controller
    {

        private TenMoviesContext? _db;
        private IWebHostEnvironment? _environment;
        private string? pathSave;
        public AddController (TenMoviesContext contex,IWebHostEnvironment path) {
        
            _db = contex;
            _environment = path;
        
        }
        public IActionResult AddMovies()
        {
            return View();
        }


        [HttpPost]
        [RequestSizeLimit(1000000)]
        [ValidateAntiForgeryToken]//Chek control sum;
        public async Task<IActionResult> UploadMovie(
            [Bind("Title,Description,Genre,PosterUrl,Runtime,Director,Actors,Language")]Movie movie,IFormFile uploadPoster) {


            if(uploadPoster is not null)
            {
                pathSave = "/imgSrc/postert/"+uploadPoster.FileName;

                using (var fileStream = new FileStream(_environment.WebRootPath + pathSave, FileMode.Create))
                {

                    await uploadPoster.CopyToAsync(fileStream);

                }

            }
             movie.PosterUrl = pathSave;
            _db.AddAsync(movie);
            _db.SaveChangesAsync();
            return RedirectToAction("AddMovies");
        }
    }
}
