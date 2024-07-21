using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.Interfaces;

 

namespace MusicPortal.BLL.Services
{
    public class MusicCrudService 
    {
        private IUnitOfWork? DB { get; set; }
        public IMusicCrud? GetCradMusic { get; private set; }
        public MusicCrudService(IUnitOfWork unit)
        {
            DB = unit;
            GetCradMusic = DB.MusicCrudRepository;
        }

        
      
    }
}
