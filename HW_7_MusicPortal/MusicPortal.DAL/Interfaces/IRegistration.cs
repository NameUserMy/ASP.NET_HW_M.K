using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Interfaces
{
    public interface IRegistration
    {
        public Task<bool> IsLoginAsync(string login);
        public Task<bool> IsNickNameAsync(string nickName);
        public void AddUserAsync(User user);
    }
}
