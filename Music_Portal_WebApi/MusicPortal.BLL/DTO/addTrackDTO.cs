using Microsoft.AspNetCore.Http;


namespace MusicPortal.BLL.DTO
{
    public class addTrackDTO
    {
        public int IdGenre { get; set; }
        public int IdPerformer { get; set; }
        public IFormFile? uploadFile { get; set; }

    }
}
