using Microsoft.EntityFrameworkCore;
using Top_10_films.Models;



var builder = WebApplication.CreateBuilder(args);

//string? connection = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=Movie.db"));



builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
