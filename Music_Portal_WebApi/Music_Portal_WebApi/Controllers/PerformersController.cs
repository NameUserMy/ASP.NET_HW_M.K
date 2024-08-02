using Microsoft.AspNetCore.Mvc;
using Music_Portal_WebApi.Services;
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
        private ChangeFileNameService? _changeFileNameService;
        public PerformersController(IMusicCradService music, IWebHostEnvironment? environment,ChangeFileNameService changeFileName, 
            ILogger<PerformersController> logger) { 
            _changeFileNameService= changeFileName;
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
                    await _MusicCrud.CreatePerformerAsync(addPerformer);
                    ModelState.AddModelError("", "is alredy");
                    return Ok(addPerformer);

                }
                else
                {
                    Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{genre.Title}\\{addPerformer.Name}");
                    await _MusicCrud.CreatePerformerAsync(addPerformer);
                    return Ok(addPerformer);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult<PerformerDTO>> PutPerformerAsync(PerformerDTO addPerformer)
        {
         
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var oldName= await _MusicCrud.GetPerformerByIdAsync(addPerformer.Id);
            
            _changeFileNameService.ChangeDirectoryAsync(oldName.Name,addPerformer.Name);
            
            await _MusicCrud?.UpdatePerformerAsync(addPerformer);
            return Ok(addPerformer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerformerAsync(int id)
        {
            await _MusicCrud?.DeletePerformerAsync(id);
            return Ok(new { performer = "Performer is delete" });
        }

    }
}
