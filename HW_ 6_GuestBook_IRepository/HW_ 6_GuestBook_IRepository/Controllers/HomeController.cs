using HW__6_GuestBook_IRepository.Data.Repository;
using HW__6_GuestBook_IRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HW__6_GuestBook_IRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository? _repository;
        private int pageSize = 6;
        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
           
            _logger = logger;
            _repository = repository;

        }

        public async Task<IActionResult> Index(int page=1)
        {
            if (HttpContext.Session.GetString("login") == null)
            {

                HttpContext.Session.SetString("login", "Гость");
            }
            var messages = await _repository.GetAllMessageAsync();
            var count= messages.Count();
            var items = await messages.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewModelMessage vievModel = new ViewModelMessage(items,pageViewModel);

            return View(vievModel);
        }


       

       
    }
}
