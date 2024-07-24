using HW_7_MusicPortal.Models;
using HW_7_MusicPortal.TegHelper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace HW_7_MusicPortal.TegHelper
{
    public class PerformerFilterPTagHelper : GenrePaginationTagHelper
    {
        public PerformerFilterPTagHelper(IUrlHelperFactory helperFactory) : base(helperFactory)
        {
        }
        protected override void AllPagination(TagHelperOutput output, bool HasPreviousPage, bool NextPage, int PageNumber, string paramName)
        {
            base.AllPagination(output, Pagination.PerformerLink.HasPreviousPage, Pagination.PerformerLink.NextPage, Pagination.PerformerLink.PageNumber, "performerPege");
        }
        protected override TagBuilder LinkForFilter()
        {
            foreach (var item in Pagination.Performers)
            {
                liFilterLink = new TagBuilder("li");
                aFilterHref = new TagBuilder("a");
                aFilterHref.Attributes["href"] = urlHelper.Action(PageAction, new { sort = item.Name });
                aFilterHref.InnerHtml.Append(item.Name);
                liFilterLink.InnerHtml.AppendHtml(aFilterHref);
                listLinkfilter.InnerHtml.AppendHtml(liFilterLink);


            }

            return listLinkfilter;
        }
    }
}



