using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; } = null!;
        public string? Performer { get; set; } = null!;
    }
}
