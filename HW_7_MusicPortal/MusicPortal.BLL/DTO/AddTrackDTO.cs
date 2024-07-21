using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO
{
    public class AddTrackDTO
    {
        public int IdGenre { get; set; }
        public int IdCategory { get; set; }
        public int IdPerformer { get; set; }
        public int IdAlbum { get; set; }
        public string? TrackTitle { get; set; }
    }
}
