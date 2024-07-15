using HW_7_MusicPortal.Services;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;
namespace MusicPortal.BLL.Services
{
    public class RegistrationService : IRegistrationService
    {

        private IUnitOfWork DB { get; set; }
        private Encryption? _encryption;
        public RegistrationService(IUnitOfWork unit,Encryption encryption)
        {
            DB=unit;
            _encryption = encryption;
        }
        public async void AddUserAsync(ConfirmUserDTO userDTO)
        {
            _encryption.Pass = userDTO.Password;
            _encryption.HashPass();
            
            var user = new User
            {
                Password = _encryption.PassDb,
                NickName=userDTO.NickName,
                Login=userDTO.Login,
                Salt=_encryption.SaltDb,
            };
            DB.Registration.AddUserAsync(user);
            await DB.SaveAsync();
        }

        public async Task<bool> IsLoginAsync(string login)
        {
           
            return (await DB.Registration.IsLoginAsync(login)) ? false : true; 
        }

        public async Task<bool> IsNickNameAsync(string nickName)
        {
            return (await DB.Registration.IsNickNameAsync(nickName)) ? false : true; ;
        }
    }
}
