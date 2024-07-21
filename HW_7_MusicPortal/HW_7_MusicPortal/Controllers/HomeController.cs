using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;

using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System.Diagnostics;

namespace HW_7_MusicPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInformationService? _InformationService;
        private readonly ILogger<HomeController>? _logger;
        private int pageSize = 3;
        
        public HomeController(IInformationService? informationService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _InformationService = informationService;
        }

        public async Task<IActionResult> Index(string sort="Music",int page = 1)
        {
            
             var Genres = await _InformationService.GetAllGenreAsync();
             var count = Genres.Count();
            _logger.LogInformation($"{count}");
             var items = Genres.Skip((page-1) * pageSize).Take(pageSize).ToList();
            
             LinkGenreViewModel pageViewModel = new LinkGenreViewModel(count, page, pageSize);
             TrackViewModel viewModelTrack = new TrackViewModel(items, pageViewModel);
             viewModelTrack.Genres = items;
             viewModelTrack.SrcTrack = await _InformationService.GetInfoTrackByLikeAsync(sort);

            /****Todo**/
            HttpContext.Session.SetString("loginGroup", "Use01ddddd");
            if (HttpContext.Session.GetString("login") == null)
            {

                HttpContext.Session.SetString("login", "Гость");
            }
            /*******/

          

            return View(viewModelTrack);
        }

       
    }
}
