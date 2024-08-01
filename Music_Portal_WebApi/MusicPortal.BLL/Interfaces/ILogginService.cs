using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces
{
    public interface ILogginService
    {
        public void IsLoginAsync(string login);
        public void GetUserByLogginAsync(string loggin);
        public bool IsSuccessful(string pass);
        public Task<bool> IsConfirm(string login);
    }
}
