

using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.DAL.Repository
{
    internal class LogginRepository : ILoggin
    {
        private readonly PortalContext? _DB;
        public LogginRepository(PortalContext context) { 
        
        _DB = context;
        
        }
        public async Task<User> GetUserByLogginAsync(string loggin)
        {
            return await _DB.Users.FirstOrDefaultAsync(l => l.Login == loggin);
        }

        public async Task<bool> IsLoginAsync(string login)
        {
            var isLogin = await _DB.Users.FirstOrDefaultAsync(u => u.Login == login);

            if (isLogin != null)
            {
                return true;
            }
            return false;
        }
    }
}
