using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;





namespace MusicPortal.DAL.Repository
{
    internal class UserCrudRepository : CradAbstractBase
    {
        PortalContext? _DB;

        public UserCrudRepository(PortalContext context)
        {
            _DB = context;
        }

        public override void Create<T>(T value)
        {
            var user = value as User;
            _DB.Users.Add(user);
        }

        public override async void Delete(int id)
        {
 
            var targetDelete= await _DB.Users.FirstOrDefaultAsync(x => x.Id ==id);
            if (targetDelete != null)
            {
                _DB.Remove(targetDelete);
            }
    
        }

        public override void Update<T>( T value)
        {
           var user=  value as User;
           var targetUpdate= _DB.Users.FirstOrDefault(x => x.Id == user.Id);
            if (targetUpdate != null)
            {
                targetUpdate.Confirmation = user.Confirmation;
                _DB.Users.Update(targetUpdate);
            }
           
        }


      
    }
}
