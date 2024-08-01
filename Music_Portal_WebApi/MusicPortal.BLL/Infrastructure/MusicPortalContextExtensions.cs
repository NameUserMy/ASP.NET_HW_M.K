using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicPortal.DAL.EF;
namespace MusicPortal.BLL.Infrastructure
{
    public static class MusicPortalContextExtensions
    {

        public static void AddMusicPortalContext(this IServiceCollection services,string connect)
        {
            services.AddDbContext<PortalContext>(option=>option.UseSqlite(connect));
        }
    }
}
