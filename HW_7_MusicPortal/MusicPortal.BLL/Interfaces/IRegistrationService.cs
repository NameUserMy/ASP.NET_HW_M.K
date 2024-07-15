using MusicPortal.BLL.DTO;


namespace MusicPortal.BLL.Interfaces
{
    public interface IRegistrationService
    {
        public Task<bool> IsLoginAsync(string login);
        public Task<bool> IsNickNameAsync(string nickName);
        public void AddUserAsync(ConfirmUserDTO user);
    }
}
