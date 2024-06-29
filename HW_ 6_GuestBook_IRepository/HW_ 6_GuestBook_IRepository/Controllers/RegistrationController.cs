using HW__6_GuestBook_IRepository.Data.Repository;
using HW__6_GuestBook_IRepository.Models;
using HW__6_GuestBook_IRepository.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HW__6_GuestBook_IRepository.Controllers
{
    public class RegistrationController : Controller
    {


        private readonly ILogger<RegistrationController>? _logger;
        private readonly Encryption? _encryption;
        public readonly IRepository? _repository;
        public RegistrationController(ILogger<RegistrationController> logger,IRepository repository, Encryption encryption) { 
        
            _repository = repository;
            _encryption = encryption;
            _logger = logger;
        }
        public IActionResult UserRegistration()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public async Task <IActionResult> CheckLogin(string login)
        {
            return Json(await _repository.IsLoginAsync(login));

        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckNickName(string nickName)
        {
            return Json(await _repository.IsNickNameAsync(nickName));

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserRegistration(ViewModelRegistration incomminUser)
        {


            if (incomminUser.Login.ToLower() == "login"||incomminUser.NickName.ToLower()=="nickName"
                ||incomminUser.Password.ToLower()=="password") {

                ModelState.AddModelError("", "The data is not correct");
            }

            if(ModelState.IsValid)
            {

                _encryption.Pass = incomminUser.Password;
                _encryption.HashPass();
                User user = new User();
                user.Password = _encryption.PassDb;
                user.Salt = _encryption.SaltDb;
                user.Login = incomminUser.Login;
                user.NickName = incomminUser.NickName;

                _repository.CreateUserAsync(user);
                _repository.SaveChangeAsync();


                return RedirectToAction("Loggin","Loggin");


            }
            return View(incomminUser);
        }


      
    }
}
