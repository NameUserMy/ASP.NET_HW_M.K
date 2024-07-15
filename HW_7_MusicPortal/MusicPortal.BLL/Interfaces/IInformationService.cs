using MusicPortal.BLL.DTO;


namespace MusicPortal.BLL.Interfaces
{
    public interface IInformationService
    {
        public Task<IEnumerable<NotConfirmUserDTO>> GetNotConfirmUser();
        public Task<IEnumerable<ConfirmUserDTO>> GetConfirmUser();

    }
}
