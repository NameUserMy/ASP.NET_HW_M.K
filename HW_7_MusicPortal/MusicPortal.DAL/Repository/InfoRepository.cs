using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.DAL.Repository
{
    public class InfoRepository : IInformation
    {

        PortalContext? _DB;
        public InfoRepository(PortalContext context)
        {
            _DB = context;
        }

        public async Task<IEnumerable<User>> GetConfirmUser()
        {
            return await Task.Run(() => _DB.Users.Where(u => u.Confirmation == true));
        }

        public async Task<IEnumerable<User>> GetNotConfirmUser()
        {
            return await Task.Run(()=> _DB.Users.Where(u => u.Confirmation == false));
        }
    }
}
