using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces
{
    public interface IUserCrudService
    {
        public Task<IEnumerable<GetUserDTO>> GetAllUserAsync();

        public Task<GetUserDTO> GetUserById(int id);

        public Task AddUserAsync(AddUserDTO user);

        public Task UpdateUserAsync(GetUserDTO user);

        public Task DeleteUserAsync(int id);
        public Task ConfirmUser(int id);
    }
}
