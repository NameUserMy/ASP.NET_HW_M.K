using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Interfaces;

namespace Music_Portal_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformersController : ControllerBase
    {
        IMusicCradService? _MusicCrud;
        ILogger<PerformersController> _Logger;
        private IWebHostEnvironment? _environment;
        public PerformersController(IMusicCradService music, IWebHostEnvironment? environment, ILogger<PerformersController> logger) { 
        
        
            _MusicCrud = music;
            _Logger = logger;
            _environment = environment;
        
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformerDTO>>>  GetAllPerformer()
        {
            var performer = await _MusicCrud.GetAllPerformerAsync();
            if (performer != null)
            {
                return performer.ToList();
            }
            return Problem("Fail");
           
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PerformerDTO>> GetPerformerByIdAsync(int id)
        {

            var performer = await _MusicCrud.GetPerformerByIdAsync(id);
            if (performer == null)
            {

               return NotFound();
            }

            return performer;

        }

        [HttpPost]
        public async Task<ActionResult<PerformerDTO>> AddPerformerAsync(PerformerDTO addPerformer)
        {



            if (string.IsNullOrEmpty(addPerformer.Name)&&string.IsNullOrEmpty(addPerformer.GenreId.ToString()))
            {

                ModelState.AddModelError("", "required");

            }
            if (ModelState.IsValid)
            {

                var genre=   await _MusicCrud.GetGenreByIdAsync(addPerformer.GenreId);

                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{genre.Title}\\{addPerformer.Name}"))
                {
                    ModelState.AddModelError("", "is alredy");

                }
                else
                {
                    Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{genre.Title}\\{addPerformer.Name}");
                    await _MusicCrud.CreatePerformerAsync(addPerformer);
                    return Ok(addPerformer);
                }
            }
            return BadRequest(ModelState);








            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            //await _MusicCrud.CreatePerformerAsync(addPerformer);
            return Ok(addPerformer);
        }

        [HttpPut]
        public async Task<ActionResult<PerformerDTO>> PutPerformerAsync(PerformerDTO addPerformer)
        {



           
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            await _MusicCrud?.UpdatePerformerAsync(addPerformer);
            return Ok(addPerformer);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerformerAsync(int id)
        {
            await _MusicCrud?.DeletePerformerAsync(id);
            return Ok(new { user = "User is delete" });
        }

    }
}
