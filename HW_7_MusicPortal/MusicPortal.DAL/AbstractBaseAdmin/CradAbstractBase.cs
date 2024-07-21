using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Repository;


namespace MusicPortal.DAL.AbstractBaseAdmin
{
    public abstract class CradAbstractBase 
    {
        public abstract void Delete(int  id);
        public abstract void Update<T>(T value);
        public abstract void Create<T>(T value);
    }
}
