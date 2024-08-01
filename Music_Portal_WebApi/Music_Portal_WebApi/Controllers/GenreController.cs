using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System.Resources;

namespace Music_Portal_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IMusicCradService? _MusicCrud;
        private IWebHostEnvironment? _environment;
        private readonly ILogger<GenreController>? _Logger;
        public GenreController(IMusicCradService music, IWebHostEnvironment? environment, ILogger<GenreController> logger)
        {
            _MusicCrud = music;
            _Logger = logger;   
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAllGenre()
        {
            var genre = await _MusicCrud.GetAllGenreAsync();
            if (genre != null)
            {
                return genre.ToList();
            }
            return Problem("Fail");

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetGenreByIdAsync(int id)
        {

            var genre = await _MusicCrud.GetGenreByIdAsync(id);
            if (genre == null)
            {

                return NotFound();
            }

            return genre;

        }

        [HttpPost]
        public async Task<ActionResult<GenreDTO>> AddGenreAsync(GenreDTO addGenre)
        {

            if (string.IsNullOrEmpty( addGenre.Title)) {

                ModelState.AddModelError("", "required");
            
            }
            if (ModelState.IsValid)
            {

                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{addGenre.Title}"))
                {
                    ModelState.AddModelError("", "is alredy");

                }
                else
                {
                        Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{addGenre.Title}");
                        await _MusicCrud.CreateGenreAsync(addGenre);
                        return Ok(addGenre);
                }
            }
            return BadRequest(ModelState);
            
        }

        [HttpPut]
        public async Task<ActionResult<GenreDTO>> PutGenreAsync(GenreDTO addGenre)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            await _MusicCrud?.UpdateGenreAsync(addGenre);
            return Ok(addGenre);
        }
     
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenreAsync(int id)
        {
            await _MusicCrud?.DeleteGenreAsync(id);
            return Ok(new { genre = "User is delete" });
        }
    }
}
