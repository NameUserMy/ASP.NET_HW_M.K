using Microsoft.Extensions.DependencyInjection;
using MusicPortal.DAL.Interfaces;
using MusicPortal.DAL.Repository;

namespace MusicPortal.BLL.Infrastructure
{
    public static class UOWExtentions
    {
        public static void AddUOW(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
