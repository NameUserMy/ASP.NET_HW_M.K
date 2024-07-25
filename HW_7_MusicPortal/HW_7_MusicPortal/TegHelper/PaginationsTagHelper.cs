using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace HW_7_MusicPortal.TegHelper
{
    public class PaginationsTagHelper:TagHelper
    {


        private TagBuilder? listPagination;//for pagination list(ul tag)

        private TagBuilder? liPaginationLink; //for pagination list(li tag)
        private TagBuilder? APaginationLink; //for pagination list(a tag)


        private TagBuilder? listLinkfilter;// for link filter (ul tag)
      


        private IUrlHelperFactory? _urlHelperFactory;
        private IUrlHelper? urlHelper;

        public PaginationsTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
            listPagination = new TagBuilder("ul");
            listLinkfilter = new TagBuilder("ul");
        }

        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;
        public  PageViewModel? PaginationTrack { get; set; }
        public string? PageAction { get; set; }
        public string? Parametr {  get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddClass("pagination-Butom", HtmlEncoder.Default);
            listPagination?.AddCssClass("TagHelperPagination pagination-filter");
            listLinkfilter?.AddCssClass("filter list-none-marker");
            urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            AllPagination(output, PaginationTrack.HasPreviousPage, PaginationTrack.NextPage, PaginationTrack.PageNumber,Parametr);
        }

        private TagBuilder PoginationHelper(IUrlHelper urlHelper, int pageNumber, int pageViewNumber, string paramName)
        {

            liPaginationLink = new TagBuilder("li");
            APaginationLink = new TagBuilder("a");

            if (pageNumber == pageViewNumber)
            {
                liPaginationLink.InnerHtml.Append(pageNumber.ToString());

            }
            else
            {
                APaginationLink.Attributes["href"] = urlHelper.Action(PageAction) + $"?{paramName}={pageNumber}";
                liPaginationLink.InnerHtml.Append(pageNumber.ToString());
            }


            APaginationLink.InnerHtml.AppendHtml(liPaginationLink);

            return APaginationLink;
        }

        private  void AllPagination(TagHelperOutput output, bool HasPreviousPage, bool NextPage, int PageNumber, string paramName)
        {

            TagBuilder currentItem = PoginationHelper(urlHelper, PageNumber, PageNumber, paramName);

            if (HasPreviousPage)
            {
                TagBuilder previous = PoginationHelper(urlHelper, PageNumber - 1, PageNumber, paramName);
                listPagination.InnerHtml.AppendHtml(previous);

            }
            listPagination.InnerHtml.AppendHtml(currentItem);

            if (NextPage)
            {

                TagBuilder nextPrev = PoginationHelper(urlHelper, PageNumber + 1, PageNumber, paramName);
                listPagination.InnerHtml.AppendHtml(nextPrev);

            }

           
            output.Content.AppendHtml(listPagination);
        }

    }

   
}
