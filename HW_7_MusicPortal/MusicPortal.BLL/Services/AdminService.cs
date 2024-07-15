using HW_7_MusicPortal.Services;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.BLL.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork DB { get; set; }
        public AdminService(IUnitOfWork unit )
        {
            DB = unit;
          
        }
        public void Delete(CradAbstractBase crad, int id)
        {
            crad.Delete(id);
            DB.SaveAsync();
        }

        public void Create(CradAbstractBase crad,ConfirmUserDTO user)
        {
            crad.Create(new User {Login=user.Login,NickName=user.NickName,Password=user.Password,Salt=user.Salt});
        }

        public void ConfirmUser(CradAbstractBase crad,int id)
        {
            crad.Update(new User { Id = id, Confirmation = true});
            DB.SaveAsync();
        }

        public void BlockUser(CradAbstractBase crad, int id)
        {
            crad.Update(new User { Id = id, Confirmation = false });
            DB.SaveAsync();
        }

      
    }
}
