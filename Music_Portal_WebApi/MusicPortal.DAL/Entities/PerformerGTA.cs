using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Entities
{
    public class PerformerGTA
    {
        public int Id{get; set; }
       
        public int GenreId {  get; set; }
        public Genre? Genre { get; set; }  
        public int TrackId {  get; set; }
        public int PerformerId { get; set; }
        public Performer? Performer { get; set; }
        public  Track? Track { get; set; }
       
    }
}
