using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.DAL.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RegistrationRepository? _reg ;
        private LogginRepository? _loggin;
        private UserCrudReposytory? _userCrudReposytory;
        private InfoRepository? _infoRepository;    
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
        public CradAbstractBase UserCrad
        {
            get
            {

                if (_userCrudReposytory == null)
                {
                    _userCrudReposytory = new UserCrudReposytory(_DB);

                }

                return _userCrudReposytory;
            }
        }

        public IInformation Information
        {
            get
            {

                if (_infoRepository == null)
                {
                    _infoRepository = new InfoRepository(_DB);

                }

                return _infoRepository;
            }

        }

        public async Task SaveAsync()
        {
            await _DB.SaveChangesAsync();
        }
    }
}
