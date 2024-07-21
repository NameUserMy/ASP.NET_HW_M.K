using Microsoft.Extensions.DependencyInjection;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;


namespace MusicPortal.BLL.Infrastructure
{
    public static class AdminExtentions
    {
        public static void  Admin (this IServiceCollection services)
        {
           services.AddScoped<IAdminService, AdminService>();
           services.AddScoped<CrudUserService>();
        }
    }
}
