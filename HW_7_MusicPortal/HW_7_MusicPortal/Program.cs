using HW_7_MusicPortal.Services;
using Microsoft.EntityFrameworkCore;
using MusicPortal.BLL.Infrastructure;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSession(configure =>
{

    configure.IdleTimeout = TimeSpan.FromMinutes(5);
    configure.Cookie.Name = "SessionLogin";

});


builder.Services.AddMusicPortalContext("Data Source=./Data/MusicPortal.db");
builder.Services.AddUOW();
builder.Services.Admin();
builder.Services.AddScoped<IRegistrationService,RegistrationService>();
builder.Services.AddScoped<IInformationService, InformationService>();
builder.Services.AddScoped<ILogginService, LogginService>();
builder.Services.AddScoped<Encryption>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
