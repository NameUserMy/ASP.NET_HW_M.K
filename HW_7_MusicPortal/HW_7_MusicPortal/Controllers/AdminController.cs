using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;

namespace HW_7_MusicPortal.Controllers
{
    public class AdminController : Controller
    {
        private IWebHostEnvironment? _environment;
        private readonly ILogger<AdminController>? _logger;
        private readonly IAdminService? _AdminService;
        private readonly IInformationService? _InformationService;
        private readonly CrudUserService? _crudUserService;
        public AdminController(IAdminService adminService, CrudUserService crudUserService, 
            IWebHostEnvironment path,ILogger<AdminController> logger,IInformationService informationService) { 
             _logger = logger;
            _environment= path;
            _AdminService = adminService;
            _crudUserService= crudUserService;
            _InformationService = informationService;
        
        }
        public IActionResult Admin()
        {
           
            return View();
        }

        public  IActionResult AddTrack()
        {

             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Chek control sum;
        public async Task<IActionResult> AddTrack(AddTrackViewModel incommingTrack, IFormFile? uploadFile)
        {

            _logger.LogInformation($"Post {uploadFile}"  );

            if (uploadFile is not null)
            {
                string pathSave = $"/Music/{incommingTrack.Genre}/{incommingTrack.Category}/{incommingTrack.Performer}/{incommingTrack.Album}/" + uploadFile.FileName;

                using (var fileStream = new FileStream(_environment.WebRootPath + pathSave, FileMode.Create))
                {

                    await uploadFile.CopyToAsync(fileStream);

                }

            }


            return View(incommingTrack);
        }

        public async  Task<IActionResult> UserMenegment()
        {
         
            UserViewModel model = new UserViewModel();

            model.NotConfirmUser = await _InformationService.GetNotConfirmUser();
            model.ConfirmUser = await _InformationService.GetConfirmUser();
             

            return View(model);
        }
        public async Task<IActionResult> ConfirmUser(int id)
        {

            _AdminService.ConfirmUser(_crudUserService.GetCradUser, id);


            return RedirectToAction("UserMenegment", "Admin");
        }
        public async Task<IActionResult> BlockUser(int id)
        {

            _AdminService.BlockUser(_crudUserService.GetCradUser, id);


            return RedirectToAction("UserMenegment", "Admin");
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            _AdminService.Delete(_crudUserService.GetCradUser,id);
            return RedirectToAction("UserMenegment", "Admin");
        }
        public IActionResult MusicMenegment()
        {
         
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGenre(GenreFormViewModel ingomminGenre)
        {

           
            _logger.LogInformation($" Perform {ingomminGenre.Performer}\nAlbum {ingomminGenre.Album}\nCategory {ingomminGenre.Category}" +
                $"\nGenre {ingomminGenre.Genre}");
            _logger.LogInformation($" OPerform {ingomminGenre.OptionPerformer}\nOAlbum {ingomminGenre.OptionCategory}\nCategory " +
                $"{ingomminGenre.OptionGenre}");

            if (!string.IsNullOrEmpty(ingomminGenre.Genre)||
                !string.IsNullOrEmpty(ingomminGenre.Genre)&&string.IsNullOrEmpty(ingomminGenre.OptionCategory)
                && string.IsNullOrEmpty(ingomminGenre.OptionGenre)&& string.IsNullOrEmpty(ingomminGenre.OptionPerformer))
            {
                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{ingomminGenre.Genre}"))
                {
                    _logger.LogInformation("Folder is Yeh");
                }
                else
                {
                    _logger.LogInformation("Folder is Created");
                    Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{ingomminGenre.Genre}");


                }
                _logger.LogInformation($"Empty");
            }
            else if(!string.IsNullOrEmpty(ingomminGenre.OptionGenre)&&!string.IsNullOrEmpty(ingomminGenre.Category))
            {

                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{ingomminGenre.Category}"))
                {
                    _logger.LogInformation("Folder is Yeh");
                }
                else
                {
                    _logger.LogInformation("Folder is Created");
                    Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.Category}");


                }
            }
            else if (!string.IsNullOrEmpty(ingomminGenre.OptionGenre)&&
                !string.IsNullOrEmpty(ingomminGenre.OptionCategory) && !string.IsNullOrEmpty(ingomminGenre.Performer))
            {

                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.OptionCategory}\\{ingomminGenre.Performer}"))
                {
                    _logger.LogInformation("Folder is Yeh");
                }
                else
                {
                    _logger.LogInformation("Folder is Created");
                    Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.OptionCategory}\\{ingomminGenre.Performer}");


                }
            }
            else if (!string.IsNullOrEmpty(ingomminGenre.OptionGenre) &&
                !string.IsNullOrEmpty(ingomminGenre.OptionCategory) && 
                !string.IsNullOrEmpty(ingomminGenre.OptionPerformer)&&
                !string.IsNullOrEmpty(ingomminGenre.Album))
            {

                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.OptionCategory}\\{ingomminGenre.OptionPerformer}\\{ingomminGenre.Album}"))
                {
                    _logger.LogInformation("Folder is Yeh");
                }
                else
                {
                    _logger.LogInformation("Folder is Created");
                    Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.OptionCategory}\\{ingomminGenre.OptionPerformer}\\{ingomminGenre.Album}");
                }
            }
            else
            {
                _logger.LogInformation($"Empty");
            }



          
            return RedirectToAction("MusicMenegment");
        }
    }
}
