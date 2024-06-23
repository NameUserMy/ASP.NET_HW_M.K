using HW_4_Top_10_CRUD.Data;
using HW_4_Top_10_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW_4_Top_10_CRUD.ViewComponents
{
    public class DetailsViewComponent:ViewComponent
    {
        private readonly TenMoviesContext? _context;
        public DetailsViewComponent(TenMoviesContext context)
        {
            _context = context;

        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AllInfoModelView modelView = new AllInfoModelView();
             var test= await _context.Movies.Where(e=>e.Id==id).FirstOrDefaultAsync();

            modelView.Title=test.Title; 
            modelView.Description=test.Description;


            return View("Default",modelView);
        }
       

    }
}
