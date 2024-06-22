using HW_4_Top_10_CRUD.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TenMoviesContext>(options => options.UseSqlite("Data Source=TenMovie.db"));


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
