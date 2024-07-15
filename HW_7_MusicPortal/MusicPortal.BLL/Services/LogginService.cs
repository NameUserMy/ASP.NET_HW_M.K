using HW_7_MusicPortal.Services;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.BLL.Services
{
    public class LogginService : ILogginService
    {
        private IUnitOfWork _DB { get; set; }
        private Encryption? _encryption;
        private ConfirmUserDTO? _userDTO;
        private bool _isLOggin;
        public LogginService(IUnitOfWork unitOfWork,Encryption encryption) { 
        
            _encryption = encryption;
            _DB = unitOfWork;    

        }
        public async void GetUserByLogginAsync(string loggin)
        {
             var userDb=  await _DB.Loggin.GetUserByLogginAsync(loggin);

            _userDTO = new ConfirmUserDTO
            {
                Login=userDb.Login,
                Password=userDb.Password,
                Salt=userDb.Salt,   
            };
           
        }

        public async void IsLoginAsync(string login)
        {
          _isLOggin= await _DB.Loggin.IsLoginAsync(login);
        }

        public bool IsSuccessful(string pass)
        {

            if (_isLOggin)
            {
                _encryption.IncomeSalt = _userDTO.Salt;
                _encryption.Pass = pass;
                _encryption.DecryptionPass();
                if (_encryption.DecryptionPass() != _userDTO.Password)
                {

                    return false;

                }


            }
            return true;
        }
    }
}
