using HW__6_GuestBook_IRepository.Data.Repository;
using HW__6_GuestBook_IRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

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

      
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("login") == null)
            {

                HttpContext.Session.SetString("login", "Гость");
            }


            return View();
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAJAX(int page=1)
        {
  
            var src = await _repository.GetAllViewMessageAsync();
            var count = src.Count();
            var items = src.Skip((page - 1) * pageSize).Take(pageSize);
            var model = JsonSerializer.Serialize(items);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
           
            return Json(model);



            


        }



    }
}
