using HW__6_GuestBook_IRepository.Data.Repository;
using HW__6_GuestBook_IRepository.Models;
using HW__6_GuestBook_IRepository.Services;
using Microsoft.AspNetCore.Mvc;
namespace HW__6_GuestBook_IRepository.Controllers
{
    public class LogginController : Controller
    {

        private readonly ILogger<RegistrationController>? _logger;
        private readonly Encryption? _encryption;
        public readonly IRepository? _repository;

        public LogginController(ILogger<RegistrationController> logger, IRepository repository, Encryption encryption) { 
        
            _logger = logger;
            _repository = repository;
            _encryption = encryption;
        
        }

        public IActionResult Loggin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Loggin(ViewModelLoggin userLoggin)
        {

            if (!await _repository.IsLoginAsync(userLoggin.Login))
            {

                var userCheck = await _repository.GetUserByLogginAsync(userLoggin.Login);
               
                    _encryption.IncomeSalt = userCheck.Salt;
                    _encryption.Pass=userLoggin.Password;
                    _encryption.DecryptionPass();
                    _logger.LogInformation($"Decrp {_encryption.DecryptionPass()}  Db {userCheck.Password} ");
                if (_encryption.DecryptionPass()!= userCheck.Password)
                {

                    ModelState.AddModelError("", "User not found");

                }


                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetString("login", userLoggin.Login);
                    return RedirectToAction("Index","Home");

                }

            }

            return View(userLoggin);
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("login", "Гость");
            return RedirectToAction("Index", "Home");
        }
    }
}
