using HW_7_MusicPortal.Filters;
using HW_7_MusicPortal.Models;
using HW_7_MusicPortal.TegHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System.Diagnostics;
using System.Linq;

namespace HW_7_MusicPortal.Controllers
{

    [Culture]
    public class HomeController : Controller
    {
        private readonly IInformationService? _InformationService;
        private readonly ILogger<HomeController>? _logger;
        private int pageSize = 2;
        private int pageSizeTrack = 8;

       
       

        public HomeController(IInformationService? informationService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _InformationService = informationService;
        }

        public async Task<IActionResult> Index(string sort = "Music",
                                               bool order=true,
                                               int page = 1,
                                               int performerPege = 1,
                                               int albumPage=1,
                                               int trackPage=1)
        {
             var Genres = await _InformationService.GetAllGenreAsync();
             var count = Genres.Count();
             var itemsG = Genres.Skip((page-1) * pageSize).Take(pageSize).ToList();
             PageViewModel pageViewModelG = new PageViewModel(count, page, pageSize);

             var Performer = await _InformationService.GetAllPerformerAsync();
             var countP=Performer.Count();
             var itemsP= Performer.Skip((performerPege - 1) * pageSize).Take(pageSize).ToList();
             PageViewModel pageViewModelP = new PageViewModel(countP, performerPege, pageSize);

            var album = await _InformationService.GetAllAlbums();
            var countA = album.Count();
            var itemsA = album.Skip((albumPage - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModelA = new PageViewModel(countA, albumPage, pageSize);


            var itemResult = await _InformationService.GetInfoTrackByLikeAsync(sort);

            var CountTrack = itemResult.Count();
            var itemsTrack= itemResult.Skip((trackPage - 1) * pageSizeTrack).Take(pageSizeTrack).ToList();
            PageViewModel pageViewModelT = new PageViewModel(CountTrack, trackPage, pageSizeTrack);

           TrackViewModel viewModelTrack = new TrackViewModel(itemsG, pageViewModelG, itemsP, pageViewModelP, itemsA, pageViewModelA,itemsTrack,pageViewModelT,order);

            if (order)
            {
                var oreder = itemsTrack.OrderByDescending(n => n.performer);//down
                viewModelTrack.SrcTrack = oreder;

            }
            else
            {

                var oreder = itemsTrack.OrderBy(n => n.performer);//Up
                viewModelTrack.SrcTrack = oreder;
            }
            /****Todo**/
            HttpContext.Session.SetString("loginGroup", "Use01ddddd");
            if (HttpContext.Session.GetString("login") == null)
            {

                HttpContext.Session.SetString("login", "Guest");
            }


            /*******/

          

            return View(viewModelTrack);
        }


        public async Task<ActionResult> Language(string Culture)
        {


            
            Response.Cookies.Append("lang", Culture);

            _logger.LogInformation($"_----------->>>>>{Culture}");
            return RedirectToAction("Index");



        }

    }
}
