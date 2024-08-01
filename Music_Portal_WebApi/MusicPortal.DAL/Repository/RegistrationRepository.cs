using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.DAL.Repository
{
    internal class RegistrationRepository : IRegistration
    {
        PortalContext? _DB;
        public RegistrationRepository(PortalContext context) { 
        
        
            _DB = context;
        
        }
        public void AddUserAsync(User user)
        {
            _DB.AddAsync(user);
        }
        public async Task<bool> IsLoginAsync(string login)
        {
          var isLogin= await _DB.Users.FirstOrDefaultAsync(u => u.Login == login);

            if(isLogin != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IsNickNameAsync(string nickName)
        {
            var isLogin = await _DB.Users.FirstOrDefaultAsync(u => u.NickName == nickName);

            if (isLogin != null)
            {
                return true;
            }
            return false;
        }

    }
}
