using Microsoft.Extensions.DependencyInjection;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
