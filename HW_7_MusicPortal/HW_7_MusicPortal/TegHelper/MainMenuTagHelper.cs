using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using HW_7_MusicPortal.Controllers.Administrator;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicPortal.DAL.Entities;
using System;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Text.Encodings.Web;

namespace HW_7_MusicPortal.TegHelper
{
    public class MainMenuTagHelper:TagHelper
    {
       

        private  readonly ILogger<MainMenuTagHelper> _logger;
        protected IUrlHelperFactory? _urlHelperFactory;
        protected IUrlHelper? urlHelper;

        private TagBuilder spanTag;
        private TagBuilder iputTag;
        private TagBuilder atTag;
        public MainMenuTagHelper(ILogger<MainMenuTagHelper> logger, IUrlHelperFactory helperFactory) { 
        
            _logger = logger;
            _urlHelperFactory = helperFactory;
            spanTag=new TagBuilder("span");
            iputTag=new TagBuilder("input");
            atTag=new TagBuilder("a");

        }
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;
        public string? PageAction { get; set; }
        public string? Usr {  get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            urlHelper.Action(PageAction);
            output.TagName = "div";
            output.AddClass("mein-menu", HtmlEncoder.Default);
            MenuMain(output);

        }

        private void MenuMain(TagHelperOutput output)
        {

            spanTag.AddCssClass("hello-User");
            spanTag.InnerHtml.Append($"Hello {Usr} !");
            output.Content.AppendHtml(spanTag);
            spanTag = new TagBuilder("span");
            iputTag.AddCssClass("left-margin-Menu custom-input-search main-align");
            iputTag.Attributes["placeholder"] = "In process";
            iputTag.Attributes["type"] = "text";
            iputTag.Attributes["disabled"]="";
            spanTag.InnerHtml.AppendHtml(iputTag);
            atTag.AddCssClass("search");
            spanTag.InnerHtml.AppendHtml(atTag);
            output.Content.AppendHtml(spanTag);

            if (Usr == "Guest")
            {
                spanTag = new TagBuilder("span");
                spanTag.AddCssClass("left-margin-Menu button-main-menu font-Setting");
                spanTag.InnerHtml.Append("Login or register");
                output.Content.AppendHtml(spanTag);

            }
            else
            {
                atTag = new TagBuilder("a");
                atTag.AddCssClass("left-margin-Menu button-main-menu");
                atTag.InnerHtml.Append("Add Trak");
                atTag.Attributes["href"] = "/User/UserAddTrack";
                output.Content.AppendHtml(atTag);

            }
            
            atTag = new TagBuilder("a");
            atTag.Attributes["Href"] = "Loggin/Logout";
            atTag.InnerHtml.Append($"Loggout");
            spanTag = new TagBuilder("span");
            spanTag.AddCssClass("loggout-User");
            spanTag.InnerHtml.AppendHtml(atTag);
            output.Content.AppendHtml(spanTag);

        }


    }
}
