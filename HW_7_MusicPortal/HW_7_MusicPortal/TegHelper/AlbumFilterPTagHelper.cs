using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HW_7_MusicPortal.TegHelper
{
    public class AlbumFilterPTagHelper : GenrePaginationTagHelper
    {
        public AlbumFilterPTagHelper(IUrlHelperFactory helperFactory) : base(helperFactory)
        {
        }



        protected override void AllPagination(TagHelperOutput output, bool HasPreviousPage, bool NextPage, int PageNumber, string paramName)
        {
            base.AllPagination(output, Pagination.AlbumsLink.HasPreviousPage, Pagination.AlbumsLink.NextPage, Pagination.AlbumsLink.PageNumber, "albumPage");
        }

        protected override TagBuilder LinkForFilter()
        {

            foreach (var item in Pagination.Albums)
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

    }
}
