using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;

namespace MusicPortal.DAL.Interfaces
{
    public interface ILoggin
    {
        public Task<bool> IsLoginAsync(string login);
        public Task<User> GetUserByLogginAsync(string loggin);
       

    }
}
