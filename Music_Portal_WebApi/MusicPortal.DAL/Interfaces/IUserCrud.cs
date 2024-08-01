using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Interfaces
{
    public interface IUserCrud
    {
        public Task<IEnumerable<User>> GetAllUserAsync();

        public Task<User> GetUserById(int id);

        public Task AddUserAsync(User user);

        public Task UpdateUserAsync(User user);

        public Task DeleteUserAsync(int id);
    }
}
