using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Portal_WebApi.Services;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;

namespace Music_Portal_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private IMusicCradService? _MusicCrud;
        private IWebHostEnvironment? _environment;
        private ChangeFileNameService? _changeFileNameService;
        private ILogger<TrackController>? _logger;
        public TrackController(IMusicCradService music, IWebHostEnvironment? environment, ChangeFileNameService changeFileName, ILogger<TrackController> logger)
        {


            _MusicCrud = music;
            _environment = environment;
            _changeFileNameService = changeFileName;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackDTO>>> GetAllTrack()
        {
            var track = await _MusicCrud.GetAllTrackAsync();
            if (track != null)
            {
                return track.ToList();
            }
            return Problem("Fail");

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TrackDTO>> GetTrackByIdAsync(int id)
        {

            var track = await _MusicCrud.GetTrackByIdAsync(id);
            if (track == null)
            {

                return NotFound();
            }

            return track;

        }

        [HttpPost]
        public async Task<ActionResult<addTrackDTO>> AddTrackAsync(addTrackDTO addTrack)
        {
            if (addTrack.uploadFile is not null)
            {

                var genre = await _MusicCrud.GetGenreByIdAsync(addTrack.IdGenre);
                var performer = await _MusicCrud.GetPerformerByIdAsync(addTrack.IdPerformer);

                string pathSave = $"/Music/{genre.Title}/{performer.Name}/" + addTrack.uploadFile.FileName;

                using (var fileStream = new FileStream(_environment.WebRootPath + pathSave, FileMode.Create))
                {
                    await addTrack.uploadFile.CopyToAsync(fileStream);
                }
                  await  _MusicCrud.CreateTrackAsync(
                    new TrackDTO { Title = addTrack.uploadFile.FileName },
                    addTrack.IdGenre,
                    addTrack.IdPerformer,
                    pathSave);

            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
           
            return Ok(addTrack);
        }

        [HttpPut]
        public async Task<ActionResult<TrackDTO>> PutTrackAsync(TrackDTO addTrack)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

          
            var oldName = await _MusicCrud.GetTrackByIdAsync(addTrack.Id);
            _changeFileNameService.ChangeFileNameAsync(oldName.Title, addTrack.Title);
            
            
            
            
            await _MusicCrud?.UpdateTrackAsync(addTrack);

            return Ok(addTrack);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTrackAsync(int id)
        {
            await _MusicCrud?.DeleteTrackAsync(id);
            return Ok(new { track = "User is delete" });
        }
    }
}
