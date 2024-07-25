using HW_7_MusicPortal.Filters;
using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;
using MusicPortal.DAL.Entities;

namespace HW_7_MusicPortal.Controllers.Administrator
{
    [Culture]
    public class AdminController : Controller
    {
       
        private readonly ILogger<AdminController>? _logger;
        private readonly IAdminService? _AdminService;
        private readonly IInformationService? _InformationService;
        private readonly CrudUserService? _crudUserService;
        public AdminController(IAdminService adminService, CrudUserService crudUserService,ILogger<AdminController> logger,IInformationService informationService

            )
        {
            _logger = logger;
            _AdminService = adminService;
            _crudUserService = crudUserService;
            _InformationService = informationService;

        }
        public async Task<IActionResult> Admin(AdminInfoDTO adminInfo)
        {

            adminInfo = await _InformationService.GetAllInfoForBoard();

            return View(adminInfo);
        }
       

      

        public async Task<IActionResult> UserMenegment(UserViewModel model)
        {

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
            _AdminService.Delete(_crudUserService.GetCradUser, id);
            return RedirectToAction("UserMenegment", "Admin");
        }
        public IActionResult MusicMenegment()
        {

            return View();
        }



       
    }
}
