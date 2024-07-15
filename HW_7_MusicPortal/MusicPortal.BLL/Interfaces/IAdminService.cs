using HW_7_MusicPortal.Services;
using MusicPortal.BLL.DTO;
using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces
{

   
    public interface IAdminService
    {
        public void Delete(CradAbstractBase crad, int id);
        public void Create(CradAbstractBase crad, ConfirmUserDTO user);
        public void ConfirmUser(CradAbstractBase crad, int id);
        public void BlockUser(CradAbstractBase crad, int id);

       

    }
}
