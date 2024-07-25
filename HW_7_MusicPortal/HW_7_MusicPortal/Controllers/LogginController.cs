using HW_7_MusicPortal.Filters;
using HW_7_MusicPortal.Models.FormModels;
using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.Interfaces;

namespace HW_7_MusicPortal.Controllers
{

    [Culture]
    public class LogginController : Controller
    {
        private readonly ILogger<RegistrationController>? _logger;
        private readonly ILogginService _logginService;
      

        public LogginController(ILogger<RegistrationController> logger, ILogginService loggin)
        {

            _logger = logger;
            _logginService = loggin;
            

        }

        public IActionResult Loggin()
        {
            return View();
        }



        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckLogin(string login)
        {
            return Json(await _logginService.IsConfirm(login));

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Loggin(ViewModelLoggin userLoggin)
        {
        
            _logginService.IsLoginAsync(userLoggin.Login);
            _logginService.GetUserByLogginAsync(userLoggin.Login);
      
            if (!_logginService.IsSuccessful(userLoggin.Password))
            {

                ModelState.AddModelError("", Resources.Resource.UserNotFound);

            }
            if (ModelState.IsValid)
            {


                if (HttpContext.Session.GetString("loginGroup") ==userLoggin.Login)
                {

                    return RedirectToAction("Admin", "Admin");
                }

                HttpContext.Session.SetString("login", userLoggin.Login);
                return RedirectToAction("Index", "Home");

            }

            return View(userLoggin);
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("login", "Guest");
            return RedirectToAction("Index", "Home");
        }
    }
}
