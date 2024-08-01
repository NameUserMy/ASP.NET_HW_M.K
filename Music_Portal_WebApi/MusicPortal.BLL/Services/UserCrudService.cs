using AutoMapper;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;


namespace MusicPortal.BLL.Services
{
    internal class UserCrudService : IUserCrudService
    {
        private IUnitOfWork DB { get; set; }
        public UserCrudService(IUnitOfWork unit)
        {
            DB = unit;

        }
        public async Task AddUserAsync(AddUserDTO user)
        {
           await DB.UserCrudRepository.AddUserAsync(new User {
                NickName=user.NickName,
                Password=user.Password,
                Login=user.Login,
                Salt=user.Salt,
 
           });
         await   DB.SaveAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
          await  DB.UserCrudRepository.DeleteUserAsync(id);
          await DB.SaveAsync();
        }

        public async Task<IEnumerable<GetUserDTO>> GetAllUserAsync()
        {

            var mapper = new MapperConfiguration(conf => conf.CreateMap<User, GetUserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<GetUserDTO>>(await DB.UserCrudRepository.GetAllUserAsync());
            
        }

        public async Task<GetUserDTO> GetUserById(int id)
        {
            var user=await DB.UserCrudRepository.GetUserById(id);
            return new GetUserDTO() {NickName=user.NickName,Login=user.Login,Id=user.Id};
        }

        public async Task UpdateUserAsync(GetUserDTO user)
        {
           await DB.UserCrudRepository.UpdateUserAsync(new User {
               Id = user.Id,
               NickName = user.NickName,
               Confirmation=user.Confirmation,
           });
           await DB.SaveAsync();
        }

        public async Task ConfirmUser(int id)
        {
          var targetUser=  await DB.UserCrudRepository.GetUserById(id);

            if (targetUser != null)
            {
                if (targetUser.Confirmation == false)
                {
                    targetUser.Confirmation = true;

                }else
                {
                    targetUser.Confirmation = false;
                }
                await DB.UserCrudRepository.UpdateUserAsync(targetUser);
                await DB.SaveAsync();

            }

        }
    }
}
