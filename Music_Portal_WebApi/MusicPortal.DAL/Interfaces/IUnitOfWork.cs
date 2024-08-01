


namespace MusicPortal.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRegistration Registration { get; }
        public ILoggin Loggin { get; }
        public IMusicCrud MusicCrudRepository { get; }

        public IUserCrud UserCrudRepository { get; }
        
        public Task SaveAsync();
    }
}
