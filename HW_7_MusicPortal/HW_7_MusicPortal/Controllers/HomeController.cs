using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;

using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System.Diagnostics;

namespace HW_7_MusicPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController>? _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public async Task<IActionResult> Index()
        {


            HttpContext.Session.SetString("loginGroup", "Use01ddddd");
          


            if (HttpContext.Session.GetString("login") == null)
            {

                HttpContext.Session.SetString("login", "Гость");
            }
            return View();
        }

       
    }
}
