

namespace MusicPortal.DAL.Entities
{
    public class Album
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public DateOnly Year { get; set; }
        public int PerformerId {  get; set; }
        public Performer? Performer { get; set; }
        public IEnumerable<Track>? Tracks { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
    }
}
