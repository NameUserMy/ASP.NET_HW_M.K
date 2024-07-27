using HW__6_GuestBook_IRepository.Data.Repository;
using HW__6_GuestBook_IRepository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HW__6_GuestBook_IRepository.Controllers
{
    public class MessageController : Controller
    {
        private string pattern= @"[?!,.a-z,A-Zа-я,А-ЯёЁ,0-9]{1,15}";
        private Regex optionRegex;
        private readonly ILogger<HomeController>? _logger;
        private readonly IRepository? _repository;
        public MessageController(ILogger<HomeController> logger, IRepository repository) { 
        
            _logger = logger;
            _repository = repository;
            optionRegex = new Regex(pattern,RegexOptions.IgnoreCase);

        }
        public IActionResult MessageSend()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> MessageSend(ViewModelPublish incommingMessage)
        {

            if (ModelState.IsValid)
            {
                await _repository.CreateMessageAsync(new Message { UserMessage = incommingMessage.Message, Theme = incommingMessage.Theme }, HttpContext.Session.GetString("login"));
                await _repository.SaveChangeAsync();
                string response = "All done";
                return Json(response);

            }
            return Problem("something wrong");
        }
    }
}
