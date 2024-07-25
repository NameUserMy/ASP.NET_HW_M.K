using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace HW_7_MusicPortal.Filters
{
    public class CultureAttribute : Attribute, IActionFilter
    {
       
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           

            var culture =  context.HttpContext.Request.Cookies["lang"];
            if (culture == null)
            {
                culture = "ru";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);


        }
    }
}
