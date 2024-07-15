

namespace MusicPortal.DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int PerformerId { get; set; }
        public Performer? Performer { get; set; }
        public int TrackId { get; set; }
        public Track? Track { get; set; }
        public int AlbumId { get; set; }
        public Album? Album { get; set; }
        
    }
}
