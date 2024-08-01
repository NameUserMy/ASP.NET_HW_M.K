
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.DAL.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RegistrationRepository? _reg ;
        private LogginRepository? _loggin;
        private MusicCrudRepository? _musicCrudReposytory;
        private UserCrudRepository? _userCrudReposytory;
        
        private readonly PortalContext? _DB;
        public EFUnitOfWork(PortalContext context) {
        
         _DB = context;
        
        }
        public IRegistration Registration
        {
            get
            {
                if (_reg == null)
                {
                    _reg=new RegistrationRepository(_DB);
                }

                return _reg;

            }
        }
        public ILoggin Loggin 
        {

            get
            {
                if (_loggin == null)
                {
                    _loggin = new LogginRepository(_DB);
                }

                return _loggin;

            }

        }
  
        public IMusicCrud MusicCrudRepository {



            get
            {
                if (_musicCrudReposytory == null)
                {
                    _musicCrudReposytory = new MusicCrudRepository(_DB);
                }

                return _musicCrudReposytory;

            }



        }

        public IUserCrud UserCrudRepository {

            get
            {
                if (_userCrudReposytory == null)
                {
                    _userCrudReposytory = new UserCrudRepository(_DB);
                }

                return _userCrudReposytory;

            }

        }

        public async Task SaveAsync()
        {
            await _DB.SaveChangesAsync();
        }
    }
}
