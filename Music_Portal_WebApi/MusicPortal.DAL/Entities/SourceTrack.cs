using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Entities
{
    public class SourceTrack
    {
        public int Id { get; set; }
        public string? Src { get; set; }
        public int TrackId { get; set; }
        public Track? Track { get; set; }
    }
}
