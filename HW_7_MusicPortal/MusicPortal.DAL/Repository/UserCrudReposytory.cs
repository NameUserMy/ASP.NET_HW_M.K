using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;

//public async Task<IEnumerable<User>> GetNotConfirmedUserAsync()
//{
//    return _DB.Users.Where(c => c.Confirmation == false);
//}

//public async Task<IEnumerable<UserDTO>> GetNotConfirmedUserAsync()
//{
//    var mapper = new MapperConfiguration(conf => conf.CreateMap<User, UserDTO>()).CreateMapper();
//    return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await DB.AdminInfo.GetNotConfirmedUserAsync());

//}



namespace MusicPortal.DAL.Repository
{
    internal class UserCrudReposytory : CradAbstractBase
    {
        PortalContext? _DB;

        public UserCrudReposytory(PortalContext context)
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
