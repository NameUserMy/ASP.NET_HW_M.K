using HW__6_GuestBook_IRepository.Data;
using HW__6_GuestBook_IRepository.Data.Repository;
using HW__6_GuestBook_IRepository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GuestBookContext>(options => options.UseSqlite("Data Source=./Data/GuestBook.db"));


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(configure =>
{

    configure.IdleTimeout = TimeSpan.FromMinutes(5);
    configure.Cookie.Name = "SessionLogin";

});
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository, GuestBookRepository>();
builder.Services.AddScoped<Encryption>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
