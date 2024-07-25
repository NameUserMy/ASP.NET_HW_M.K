using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;
using MusicPortal.BLL.DTO;

namespace HW_7_MusicPortal.TegHelper
{
    public class LanguageTagHelper: TagHelper
    {

        private IUrlHelperFactory? _urlHelperFactory;
        private IUrlHelper? urlHelper;
        private ILogger<LanguageTagHelper> _logger;
        private readonly ILanguageListService? _languageListService;
        public LanguageTagHelper(IUrlHelperFactory helperFactory, ILanguageListService languageList, ILogger<LanguageTagHelper> logger)
        {
           

          
            _languageListService = languageList;
            _urlHelperFactory = helperFactory;
            _logger = logger;
            //var Performer = await _InformationService.GetAllPerformerAsync();
            //var countP = Performer.Count();
            //var itemsP = Performer.Skip((performerPege - 1) * pageSize).Take(pageSize).ToList();
            //PageViewModel pageViewModelP = new PageViewModel(countP, performerPege, pageSize);





        }
       
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;
        public string? PageAction { get; set; }
       
       
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
             urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
          





            LinkLang(output);

           


        }
        private void LinkLang(TagHelperOutput output)
        {


            foreach (var language in _languageListService.LanguageList())
            {
                TagBuilder aTag = new TagBuilder("a");
                aTag.InnerHtml.Append(language.Name);
                aTag.Attributes["href"] = urlHelper.Action(PageAction, new { CultureUser = language.Culture });
                output.Content.AppendHtml(aTag);
            }


        }
    }
}
