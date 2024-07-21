using MusicPortal.BLL.DTO;
using MusicPortal.DAL.AbstractBaseAdmin;



namespace MusicPortal.BLL.Interfaces
{


    public interface IAdminService : IUserCrudService, IMusicCrudService
    {
        public void Delete(CradAbstractBase crad, int id);
        public void Create(CradAbstractBase crad, ConfirmUserDTO user);
        public void ConfirmUser(CradAbstractBase crad, int id);
        public void BlockUser(CradAbstractBase crad, int id);
        
    }
}
