
using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.Repository;

namespace MusicPortal.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRegistration Registration { get; }
        public ILoggin Loggin { get; }
        public CradAbstractBase UserCrad { get; }
        public IInformation Information { get; }
        public Task SaveAsync();
    }
}
