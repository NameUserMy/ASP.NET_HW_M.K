using MusicPortal.BLL.DTO;

namespace HW_7_MusicPortal.Models
{
    public class UserViewModel
    {
        public IEnumerable<ConfirmUserDTO>? ConfirmUser { get; set; }
        public IEnumerable<NotConfirmUserDTO>? NotConfirmUser { get; set; }

    }
}
