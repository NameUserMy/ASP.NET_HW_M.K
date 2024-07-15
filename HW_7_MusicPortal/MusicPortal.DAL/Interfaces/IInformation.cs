using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Interfaces
{
    public interface IInformation
    {
        public Task <IEnumerable<User>> GetConfirmUser();
        public Task<IEnumerable<User>> GetNotConfirmUser();

    }
}
