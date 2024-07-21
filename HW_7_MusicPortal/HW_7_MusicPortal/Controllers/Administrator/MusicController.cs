using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPortal.DAL.Entities;

namespace HW_7_MusicPortal.Controllers.Administrator
{
    public class MusicController : Controller
    {

        private readonly IInformationService? _InformationService;
        private readonly IAdminService? _AdminService;
        private IWebHostEnvironment? _environment;
        private readonly ILogger<MusicController>? _logger;
        public MusicController(
            IInformationService informationService,
            IAdminService adminService,
            IWebHostEnvironment path,
            ILogger<MusicController> logger) { 
        
            _InformationService = informationService;
            _AdminService = adminService;
            _environment = path;
            _logger = logger;
        
        
        }
        public async Task<IActionResult> AditGenre(EditGenreViewModel infoGenre)
        {
            infoGenre.Genre = await _InformationService.GetAllGenreAsync();
            return View(infoGenre);
        }
        public async Task<IActionResult> DeleteGenre(int id)
        {

            _logger.LogInformation($"{id}");
            await _AdminService.DeleteGenreAsync(id);

            return RedirectToAction("AditGenre");
        }

        public async Task<IActionResult> ConFirm(EditGenreViewModel genreUpdate)
        {

            var oldPath = await _InformationService.GetGenreAsync(genreUpdate.GenreId);
            string targetUpdate = _environment.WebRootPath + $"\\Music\\{oldPath.Title}";
            DirectoryInfo di = new DirectoryInfo(targetUpdate);
            await Task.Run(() => di.MoveTo($"{_environment.WebRootPath}\\Music\\{genreUpdate.GenreTitel}"));
            await _AdminService.UpdateGenreAsync(new GenreDTO { Title=genreUpdate.GenreTitel,Id=genreUpdate.GenreId});
            await _AdminService.UpdateSrcExcute($"/Music/{oldPath.Title}", $"/Music/{genreUpdate.GenreTitel}");
            return RedirectToAction("AditGenre");
        }

        public async Task<IActionResult> AddGenre()
        {
            GenreViewModel ingomminGenre=new GenreViewModel();
            ingomminGenre.CategoryL = new SelectList(await _InformationService.GetAllCategoryAsync(), nameof(Category.Title), nameof(Category.Title));
            ingomminGenre.PerformerL = new SelectList(await _InformationService.GetAllPerformerAsync(), nameof(Performer.Name), nameof(Performer.Name));
            ingomminGenre.GenriL = new SelectList(await _InformationService.GetAllGenreAsync(), nameof(Genre.Title), nameof(Genre.Title));
            return View(ingomminGenre);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGenre(GenreViewModel ingomminGenre)
        {

            if (!string.IsNullOrEmpty(ingomminGenre.Genre))
            {
                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{ingomminGenre.Genre}"))
                {
                    ModelState.AddModelError("", "Genre has already");

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{ingomminGenre.Genre}");
                        await _AdminService?.CreateGenreAsync(new CreateGenreDTO { Genre = ingomminGenre.Genre });
                        return RedirectToAction("AddGenre");
                    }
                  


                }

            }
            else if (!string.IsNullOrEmpty(ingomminGenre.OptionGenre) && !string.IsNullOrEmpty(ingomminGenre.Category))
            {

                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.Category}"))
                {
                    ModelState.AddModelError("", "Category has already");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.Category}");
                        await _AdminService.CreateCategoryAsync(new CreateGenreDTO { Category = ingomminGenre.Category });
                    }
                }
            }
            else if (!string.IsNullOrEmpty(ingomminGenre.OptionGenre) &&
                !string.IsNullOrEmpty(ingomminGenre.OptionCategory) && !string.IsNullOrEmpty(ingomminGenre.Performer))
            {

                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.OptionCategory}\\{ingomminGenre.Performer}"))
                {
                    ModelState.AddModelError("", "Performer has already");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.OptionCategory}\\{ingomminGenre.Performer}");
                        await _AdminService.CreatePerformerAsync(new CreateGenreDTO { Performer = ingomminGenre.Performer });
                    }
                }
            }
            else if (!string.IsNullOrEmpty(ingomminGenre.OptionGenre) &&
                !string.IsNullOrEmpty(ingomminGenre.OptionCategory) &&
                !string.IsNullOrEmpty(ingomminGenre.OptionPerformer) &&
                !string.IsNullOrEmpty(ingomminGenre.Album))
            {

                if (Directory.Exists(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.OptionCategory}\\{ingomminGenre.OptionPerformer}\\{ingomminGenre.Album}"))
                {
                    ModelState.AddModelError("", "Album has already");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + $"\\Music\\{ingomminGenre.OptionGenre}\\{ingomminGenre.OptionCategory}\\{ingomminGenre.OptionPerformer}\\{ingomminGenre.Album}");
                        await _AdminService.CreateAlbumAsync(new CreateGenreDTO { Album = ingomminGenre.Album });
                        return RedirectToAction("AddGenre");
                    }
                }
            }
            else
            {
                _logger.LogInformation($"Empty");
                if (!string.IsNullOrEmpty(ingomminGenre.Category)&&string.IsNullOrEmpty(ingomminGenre.OptionGenre))
                {

                    ModelState.AddModelError("", "category only in Gnere");

                }
                if (!string.IsNullOrEmpty(ingomminGenre.Performer) && string.IsNullOrEmpty(ingomminGenre.OptionCategory))
                {

                    ModelState.AddModelError("", "Performer only in Category");

                }

                if (!string.IsNullOrEmpty(ingomminGenre.Album) && 
                    string.IsNullOrEmpty(ingomminGenre.OptionPerformer)|| 
                    string.IsNullOrEmpty(ingomminGenre.OptionCategory)||
                    string.IsNullOrEmpty(ingomminGenre.OptionGenre))
                {

                    ModelState.AddModelError("", "Album  only in genre -> category -> Performer");
         
                    
                   

                }
               


            }

            //To--do Check path
            ingomminGenre.CategoryL = new SelectList(await _InformationService.GetAllCategoryAsync(), nameof(Category.Title), nameof(Category.Title));
            ingomminGenre.PerformerL = new SelectList(await _InformationService.GetAllPerformerAsync(), nameof(Performer.Name), nameof(Performer.Name));
            ingomminGenre.GenriL = new SelectList(await _InformationService.GetAllGenreAsync(), nameof(Genre.Title), nameof(Genre.Title));
            return View(ingomminGenre);
          
        }

        public async Task<IActionResult> AddTrack()
        {

            AddTrackViewModel vm = new AddTrackViewModel();
            vm.Genre = new SelectList(await _InformationService.GetAllGenreAsync(), nameof(Genre.Id), nameof(Genre.Title));
            vm.Category = new SelectList(await _InformationService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Title));
            vm.Performer = new SelectList(await _InformationService.GetAllPerformerAsync(), nameof(Performer.Id), nameof(Performer.Name));
            vm.Album = new SelectList(await _InformationService.GetAlbums(), nameof(Album.Id), nameof(Album.Title));

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//Chek control sum;
        public async Task<IActionResult> AddTrack(AddTrackViewModel incommingTrack, IFormFile? uploadFile)
        {

            if(ModelState.IsValid)
            {

                string PathToTrack = await _AdminService.PathTrack(incommingTrack.PerformerId.Value, incommingTrack.GenreId.Value,
                      incommingTrack.CategoryId.Value, incommingTrack.AlbumId.Value);


                if (uploadFile is not null)
                {
                    string pathSave = $"/Music/{PathToTrack}/" + uploadFile.FileName;

                    using (var fileStream = new FileStream(_environment.WebRootPath + pathSave, FileMode.Create))
                    {

                        await uploadFile.CopyToAsync(fileStream);

                        await _AdminService.CreateTrackAsync(new AddTrackDTO
                        {
                            IdAlbum = incommingTrack.AlbumId.Value,
                            IdCategory = incommingTrack.CategoryId.Value,
                            IdGenre = incommingTrack.GenreId.Value,
                            IdPerformer = incommingTrack.PerformerId.Value,
                            TrackTitle = uploadFile.FileName

                        }, pathSave);

                    }

                }
                return RedirectToAction("AddTrack");

            }


            incommingTrack.Genre = new SelectList(await _InformationService.GetAllGenreAsync(), nameof(Genre.Id), nameof(Genre.Title));
            incommingTrack.Category = new SelectList(await _InformationService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Title));
            incommingTrack.Performer = new SelectList(await _InformationService.GetAllPerformerAsync(), nameof(Performer.Id), nameof(Performer.Name));
            incommingTrack.Album = new SelectList(await _InformationService.GetAlbums(), nameof(Album.Id), nameof(Album.Title));
            return View(incommingTrack);
        }

    }
}
