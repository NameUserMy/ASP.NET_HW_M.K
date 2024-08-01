using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;


namespace Music_Portal_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        IUserCrudService? _userCrudService;
        ILogger<UserController>? _logger;

        public UserController(IUserCrudService user, ILogger<UserController>? logger)
        {
            _userCrudService = user;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDTO>>> GetUserAll()
        {
            

            var track = await _userCrudService.GetAllUserAsync();
            return track.ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDTO>> GetUserByIdAsync(int id)
        {

            var user = await _userCrudService.GetUserById(id);
            if (user == null)
            {

                return NotFound();
            }

            return user;

        }

        [HttpPost]
        public async Task<ActionResult<AddUserDTO>> AddUserAsync(AddUserDTO addUser)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            await _userCrudService?.AddUserAsync(addUser);
            return Ok(addUser);
        }

        [HttpPut]
        public async Task<ActionResult<GetUserDTO>> PutUserAsync(GetUserDTO addUser)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            await _userCrudService?.UpdateUserAsync(addUser);
            return Ok(addUser);
        }
       
        [HttpPut("{id}")]
        public async Task<ActionResult<AddUserDTO>> PutUserAsync(int id)
        {


            _logger.LogInformation($"{id}");

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            await _userCrudService?.ConfirmUser(id);
            return Ok(new {User=$"User {id} is Update"});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
             await _userCrudService?.DeleteUserAsync(id);
             return Ok(new {user="User is delete" });
        }


    }
}


    

