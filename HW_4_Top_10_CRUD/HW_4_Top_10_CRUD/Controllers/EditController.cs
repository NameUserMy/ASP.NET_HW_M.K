using HW_4_Top_10_CRUD.Data;
using HW_4_Top_10_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW_4_Top_10_CRUD.Controllers
{
    public class EditController : Controller
    {

        private readonly TenMoviesContext? _context;
        private IWebHostEnvironment? _environment;
        private string? pathSave;
        public EditController(TenMoviesContext context, IWebHostEnvironment path)
        {
            _context = context;
            _environment = path;

        }
        public async Task<IActionResult>  EditMovie(int id)
        {

            AllInfoModelView modelView = new AllInfoModelView();
            var src = await _context.Movies.Where(e => e.Id == id).FirstAsync();

            modelView.Id = src.Id;
            modelView.Title = src.Title;
            modelView.Description = src.Description;
            modelView.Actors = src.Actors;
            modelView.Director = src.Director;
            modelView.Genre = src.Genre;
            modelView.Language = src.Language;
            modelView.PosterUrl = src.PosterUrl;
            modelView.Year = src.Year;
            modelView.Runtime = src.Runtime;    

            return View(modelView);
        }


        [HttpPost]
        [RequestSizeLimit(1000000)]
        [ValidateAntiForgeryToken]//Chek control sum;
        public async Task <IActionResult> UpDateMovie(
           [Bind("Id,Title,Description,Genre,PosterUrl,Runtime,Director,Actors,Language,Year")] AllInfoModelView movie, IFormFile uploadPoster)
        {


            if (uploadPoster is not null)
            {
                pathSave = "/imgSrc/posters/" + uploadPoster.FileName;

                using (var fileStream = new FileStream(_environment.WebRootPath + pathSave, FileMode.Create))
                {

                   await uploadPoster.CopyToAsync(fileStream);

                }

            }

            var target= await _context.Movies.FirstOrDefaultAsync(e=>e.Id==movie.Id);
            if(target != null)
            {

                target.Title=movie.Title;

                target.Title = movie.Title;
                target.Description = movie.Description;
                target.Actors = movie.Actors;
                target.Director = movie.Director;
                target.Genre = movie.Genre;
                target.Language = movie.Language;
                target.Runtime = movie.Runtime;
                target.Year = movie.Year;
                if (uploadPoster is not null)
                {
                    target.PosterUrl = pathSave;
                }
               await _context.SaveChangesAsync();


            }

            
            return RedirectToAction("Index","Home");
        }
    }
}
