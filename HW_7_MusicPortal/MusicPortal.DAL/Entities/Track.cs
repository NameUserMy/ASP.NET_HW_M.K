using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Entities
{
    public class Track
    {
        public int id { get; set;}
        public string? Title { get; set;}
        public int PerformerId { get; set; }
        public Performer? Performer { get; set; }
        public int AlbumId { get; set; }
        public Album? Album { get; set; }
        public IEnumerable<Genre>? Tracks { get; set; }
    }
}
