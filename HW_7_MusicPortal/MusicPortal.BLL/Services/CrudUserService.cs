using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.BLL.Services
{
    public class CrudUserService
    {
        private IUnitOfWork? DB { get; set; }
        public CradAbstractBase? GetCradUser { get; private set; }
        public CrudUserService(IUnitOfWork unit)
        {
            DB = unit;
            GetCradUser = DB.UserCrad;
        }


    }
}
