using HW_7_MusicPortal.Models.FormModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;
using MusicPortal.DAL.Entities;

namespace HW_7_MusicPortal.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IInformationService? _InformationService;
        private readonly IAdminService? _AdminService;
        private IWebHostEnvironment? _environment;


        public UserController(IInformationService? InformationService,IAdminService adminService,IWebHostEnvironment path)
        {
            _environment = path;
            _AdminService = adminService;
            _InformationService = InformationService;
        }

        public async Task<IActionResult> UserAddTrack()
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
        public async Task<IActionResult> UserAddTrack(AddTrackViewModel incommingTrack, IFormFile? uploadFile)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction("UserAddTrack");

            }


            incommingTrack.Genre = new SelectList(await _InformationService.GetAllGenreAsync(), nameof(Genre.Id), nameof(Genre.Title));
            incommingTrack.Category = new SelectList(await _InformationService.GetAllCategoryAsync(), nameof(Category.Id), nameof(Category.Title));
            incommingTrack.Performer = new SelectList(await _InformationService.GetAllPerformerAsync(), nameof(Performer.Id), nameof(Performer.Name));
            incommingTrack.Album = new SelectList(await _InformationService.GetAllAlbums(), nameof(Album.Id), nameof(Album.Title));
            return View(incommingTrack);
        }
    }
}
