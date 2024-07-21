

namespace MusicPortal.DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Performer>? Performers { get; set; }
    }
}
