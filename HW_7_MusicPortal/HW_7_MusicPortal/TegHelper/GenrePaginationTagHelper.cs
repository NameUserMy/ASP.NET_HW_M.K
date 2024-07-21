using HW_7_MusicPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HW_7_MusicPortal.TegHelper
{
    public class GenrePaginationTagHelper:TagHelper
    {
        
        
        private IUrlHelperFactory? _urlHelperFactory;

        public GenrePaginationTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;

        }
        [ViewContext]
        public ViewContext ViewContext { get; set; } = null!;
        public TrackViewModel Pagination { get; set; }
        public string PageAction {  get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

          


            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";
            TagBuilder tagUl = new TagBuilder("ul");
            tagUl.AddCssClass("TagHelperPagination");
            TagBuilder liGnre;
            TagBuilder aGnre;

           

            foreach (var item in Pagination.Genres)
            {
                liGnre = new TagBuilder("li");
                aGnre = new TagBuilder("a");
                aGnre.Attributes["href"] = urlHelper.Action(PageAction, new { sort = item.Title});
                aGnre.InnerHtml.Append(item.Title);
                liGnre.InnerHtml.AppendHtml(aGnre);
                tagUl.InnerHtml.AppendHtml(liGnre);


            }


            TagBuilder currentItem = ListHelper(urlHelper,Pagination.GenresLink.PageNumber);
            
            if (Pagination.GenresLink.HasPreviousPage)
            {
                TagBuilder previous = ListHelper(urlHelper, Pagination.GenresLink.PageNumber - 1);
                tagUl.InnerHtml.AppendHtml(previous);

            }
            tagUl.InnerHtml.AppendHtml(currentItem);

          


            if (Pagination.GenresLink.NextPage)
            {

                TagBuilder nextPrev = ListHelper(urlHelper, Pagination.GenresLink.PageNumber + 1);
                tagUl.InnerHtml.AppendHtml(nextPrev);

            }
           
            output.Content.AppendHtml(tagUl);
            
            base.Process(context, output);
        }


        private TagBuilder ListHelper(IUrlHelper urlHelper,int pageNumber)
        {

            TagBuilder tagLi = new TagBuilder("li");
            TagBuilder tagA=new TagBuilder("a");

            if (pageNumber ==Pagination.GenresLink?.PageNumber) {

                
                tagLi.InnerHtml.Append(pageNumber.ToString());
                tagLi.AddCssClass("activli");


            }
            else
            {

                tagA.Attributes["href"] = urlHelper.Action(PageAction, new {page = pageNumber });
                tagA.InnerHtml.Append(pageNumber.ToString());

            }

            tagLi.AddCssClass("liAny");
            tagLi.InnerHtml.AppendHtml(tagA);

            

            return tagLi;
        }




    }
}
