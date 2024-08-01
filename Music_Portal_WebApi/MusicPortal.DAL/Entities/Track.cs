using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Entities
{
    public class Track
    {
        public int Id { get; set;}
        public string? Title { get; set;}
        public SourceTrack? Source { get; set;}
        public IEnumerable<Performer>? Performers { get; set;}
        
    }
}
