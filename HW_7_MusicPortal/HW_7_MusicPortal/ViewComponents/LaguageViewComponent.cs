using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPortal.BLL.DTO;
namespace HW_7_MusicPortal.ViewComponents
{
    public class LanguageViewComponent : ViewComponent
    {

        private ILogger<LanguageViewComponent> logger;
        private ILanguageListService? _languageListService;
   
        public LanguageViewComponent(ILogger<LanguageViewComponent> logger,ILanguageListService language) { 
        
        
            _languageListService = language;
            this.logger = logger;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            LanguageViewModel languageViewModel = new LanguageViewModel();
            languageViewModel.Languages =new SelectList( _languageListService.LanguageList(),nameof(LLDTO.Culture),nameof(LLDTO.Name));
            return View("Language", languageViewModel);
        }

    }
}
