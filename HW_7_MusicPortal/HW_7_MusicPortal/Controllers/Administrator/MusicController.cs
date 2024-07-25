using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPortal.DAL.Entities;
using HW_7_MusicPortal.Models.FormModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HW_7_MusicPortal.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HW_7_MusicPortal.Controllers.Administrator
{
    [Culture]
    public class MusicController : Controller
    {

        private readonly IInformationService? _InformationService;
        private readonly IAdminService? _AdminService;
        private IWebHostEnvironment? _environment;
        private readonly ILogger<MusicController>? _logger;
        private const int pageSize = 24;
        private const int pageSizeTrack = 24;
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
        public async Task<IActionResult> EditGenre(int page=1)
        {
            var Genres = await _InformationService.GetAllGenreAsync();
            var count = Genres.Count();
            var itemsG = Genres.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModelG = new PageViewModel(count, page, pageSize);
            EditGenreViewModel infoGenre = new EditGenreViewModel(pageViewModelG, itemsG);

            return View(infoGenre);
        }
        public async Task<IActionResult> EditTrack(int editPageTrack=1)
        {
            var tracks = await _InformationService.GetAllTrackAsync();
            var count = tracks.Count();
            var items = tracks.Skip((editPageTrack - 1) * pageSizeTrack).Take(pageSizeTrack).ToList();
            PageViewModel pageViewModelEditT = new PageViewModel(count, editPageTrack, pageSizeTrack);
            EditTrackViewModel ifoTrack = new EditTrackViewModel(items, pageViewModelEditT);
            return View(ifoTrack);
        }
        public async Task<IActionResult> DeleteGenre(int id)// only Db
        {
            await _AdminService.DeleteGenreAsync(id);
            return RedirectToAction("EditGenre");
        }/** To-do Delete Local **/
        public async Task<IActionResult> DeleteTrack(int id)// only Db
        {
            await _AdminService.DeleteTrackAsync(id);
            return RedirectToAction("EditTrack");
        }/** To-do Delete Local **/

        public async Task<IActionResult> ConFirm(EditGenreViewModel genreUpdate=null!)
        {
            //_logger.LogInformation(${ })

            var oldPath = await _InformationService.GetGenreAsync(genreUpdate.GenreId);
            string targetUpdate = _environment.WebRootPath + $"\\Music\\{oldPath.Title}";
            DirectoryInfo di = new DirectoryInfo(targetUpdate);
            await Task.Run(() => di.MoveTo($"{_environment.WebRootPath}\\Music\\{genreUpdate.GenreTitel}"));
            await _AdminService.UpdateGenreAsync(new GenreDTO { Title=genreUpdate.GenreTitel,Id=genreUpdate.GenreId});
            await _AdminService.UpdateSrcExcute($"/Music/{oldPath.Title}", $"/Music/{genreUpdate.GenreTitel}");
            return RedirectToAction("EditGenre");
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
                    ModelState.AddModelError("", Resources.Resource.GenreHasAlready);

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
                    ModelState.AddModelError("", Resources.Resource.CategoryHasAlready);
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
                    ModelState.AddModelError("", Resources.Resource.PerformerHasAlready);
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
                    ModelState.AddModelError("",Resources.Resource.AlbumHasAlready);
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
                
                if (!string.IsNullOrEmpty(ingomminGenre.Category)&&string.IsNullOrEmpty(ingomminGenre.OptionGenre))
                {

                    ModelState.AddModelError("", Resources.Resource.CategoryOnlyInGnere);

                }
                if (!string.IsNullOrEmpty(ingomminGenre.Performer) && string.IsNullOrEmpty(ingomminGenre.OptionCategory))
                {

                    ModelState.AddModelError("", Resources.Resource.PerformerOnlyInCategory);

                }

                if (!string.IsNullOrEmpty(ingomminGenre.Album) && 
                    string.IsNullOrEmpty(ingomminGenre.OptionPerformer)|| 
                    string.IsNullOrEmpty(ingomminGenre.OptionCategory)||
                    string.IsNullOrEmpty(ingomminGenre.OptionGenre))
                {

                    ModelState.AddModelError("", Resources.Resource.AlbumOnly);
         
                    
                   

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
            vm.Album = new SelectList(await _InformationService.GetAllAlbums(), nameof(Album.Id), nameof(Album.Title));

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

            ModelState.AddModelError("", Resources.Resource.TrackAdd);

            incommingTrack.Genre = new SelectList(await _InformationService.GetAllGenreAsync(), nameof(Genre.Id), nameof(Genre.Title));
            incommingTrack.Category = new SelectList(await _InformationService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Title));
            incommingTrack.Performer = new SelectList(await _InformationService.GetAllPerformerAsync(), nameof(Performer.Id), nameof(Performer.Name));
            incommingTrack.Album = new SelectList(await _InformationService.GetAllAlbums(), nameof(Album.Id), nameof(Album.Title));
            return View(incommingTrack);
        }
        public async Task<IActionResult> ConFirmTrack(EditTrackViewModel ifoTrack)
        {
            var oldTrackName = await _InformationService.GetTrackAsync(ifoTrack.TrackId);

            ChangeFileNameAsync(oldTrackName.Title,ifoTrack.TrackTitel);//Update file in server

            // Update Path in BD
            await _AdminService.UpdateTrackkAsync(new TrackDTO { Title = ifoTrack.TrackTitel, Id = ifoTrack.TrackId });
            await _AdminService.UpdateSrcExcute($"{oldTrackName.Title}", $"{ifoTrack.TrackTitel}");
            return RedirectToAction("EditTrack");
        }
        private void ChangeFileNameAsync(string oldname,string newName )
        {

            string path = _environment.WebRootPath + "\\Music";
            string searchPattern = $"{oldname}";
            string[] filePaths = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);

            string blah = "";

            Task.Run(() => {
                foreach (string filePath in filePaths)
                {
                    blah = filePath;
                }
                FileInfo fileInfo = new FileInfo(blah);
                fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + $"{newName}");
            });
           

        }


       



    }
}
