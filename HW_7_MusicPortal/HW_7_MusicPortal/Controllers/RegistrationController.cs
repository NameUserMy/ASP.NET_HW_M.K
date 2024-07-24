using HW_7_MusicPortal.Services;
using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.DTO;
using HW_7_MusicPortal.Models.FormModels;

namespace HW_7_MusicPortal.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController>? _logger;
        private readonly IRegistrationService? _registeredServices;

        public RegistrationController(IRegistrationService registeredServices,ILogger<RegistrationController>? logger)
        {
           
            _registeredServices = registeredServices;
            _logger = logger;
        }
        public IActionResult UserRegistration()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckLogin(string login)
        {
            return Json(await _registeredServices.IsLoginAsync(login));

        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckNickName(string nickName)
        {
            return Json(await _registeredServices.IsNickNameAsync(nickName));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserRegistration(ViewModelRegistration incomminUser)
        {
            if (incomminUser.Login.ToLower() == "login" || incomminUser.NickName.ToLower() == "nickName"
                || incomminUser.Password.ToLower() == "password")
            {

                ModelState.AddModelError("", "The data is not correct");
            }

            if (ModelState.IsValid)
            {
                ConfirmUserDTO user = new ConfirmUserDTO();
                user.Password = incomminUser.Password;
                user.Login = incomminUser.Login;
                user.NickName = incomminUser.NickName;
                _registeredServices.AddUserAsync(user);
                return RedirectToAction("Index", "Home");


            }
            return View(incomminUser);
        }
    }
}
