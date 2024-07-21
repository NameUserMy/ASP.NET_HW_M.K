

namespace MusicPortal.DAL.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Performer>? Performers { get; set; }
    }
}
