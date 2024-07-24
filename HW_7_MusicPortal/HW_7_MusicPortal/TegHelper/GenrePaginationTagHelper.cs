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
    public  class GenrePaginationTagHelper:TagHelper
    {

        
        protected TagBuilder? listPagination;//for pagination list(ul tag)

        protected TagBuilder? liPaginationLink; //for pagination list(li tag)
        protected TagBuilder? APaginationLink; //for pagination list(a tag)


        protected TagBuilder? listLinkfilter;// for link filter (ul tag)
        protected TagBuilder? liFilterLink;//li for link filtration (li tag)
        protected TagBuilder? aFilterHref;// a for link filtration (a tag)

        protected TagBuilder? aPaginationOrdrBy;



        protected IUrlHelperFactory? _urlHelperFactory;
        protected IUrlHelper? urlHelper;

        public GenrePaginationTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
            listPagination = new TagBuilder("ul");
            listLinkfilter = new TagBuilder("ul");
            aPaginationOrdrBy = new TagBuilder("a");

        }
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;
        public virtual TrackViewModel Pagination { get; set; }
        public string PageAction {  get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            
            output.TagName = "div";
            output.AddClass("card-filter",HtmlEncoder.Default);
            listPagination?.AddCssClass("TagHelperPagination pagination-filter");
            listLinkfilter?.AddCssClass("filter list-none-marker");
            AllPagination(output, Pagination.GenresLink.HasPreviousPage, Pagination.GenresLink.NextPage, Pagination.GenresLink.PageNumber,"page");
        }
        protected virtual TagBuilder PoginationHelper(IUrlHelper urlHelper,int pageNumber,int pageViewNumber,string paramName)
        {

            liPaginationLink = new TagBuilder("li");
            APaginationLink = new TagBuilder("a");

            if (pageNumber == pageViewNumber) {
                liPaginationLink.InnerHtml.Append(pageNumber.ToString());
               
            }
            else 
            {
                APaginationLink.Attributes["href"] = urlHelper.Action(PageAction)+$"?{paramName}={pageNumber}";
                liPaginationLink.InnerHtml.Append(pageNumber.ToString());
            }


            APaginationLink.InnerHtml.AppendHtml(liPaginationLink);

            return APaginationLink;
        }
        protected virtual TagBuilder LinkForFilter()
        {

            foreach (var item in Pagination.Genres)
            {
                liFilterLink = new TagBuilder("li");
                aFilterHref = new TagBuilder("a");
                aFilterHref.Attributes["href"] = urlHelper.Action(PageAction, new { sort = item.Title });
                aFilterHref.InnerHtml.Append(item.Title);
                liFilterLink.InnerHtml.AppendHtml(aFilterHref);
                listLinkfilter.InnerHtml.AppendHtml(liFilterLink);


            }

            return listLinkfilter;
        }
        protected virtual void AllPagination(TagHelperOutput output, bool HasPreviousPage,bool NextPage,int PageNumber, string paramName)
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

            output.Content.AppendHtml(LinkForFilter());




            if ((bool)Pagination.OrderBy)
            {
                aPaginationOrdrBy.AddCssClass("order-by");
                Pagination.OrderBy = false;

            }
            else
            {
                Pagination.OrderBy = true;
                aPaginationOrdrBy.AddCssClass("order-by-down");
            }

            aPaginationOrdrBy.Attributes["href"] = urlHelper.Action(PageAction, new { order = Pagination.OrderBy });
            listPagination.InnerHtml.AppendHtml(aPaginationOrdrBy);
            output.Content.AppendHtml(listPagination);



        }


    }
}
