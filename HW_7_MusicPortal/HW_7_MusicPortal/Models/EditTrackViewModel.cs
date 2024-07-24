using MusicPortal.BLL.DTO;

namespace HW_7_MusicPortal.Models
{
    public class EditTrackViewModel
    {
        public string? TrackTitel { get; set; }
        public int TrackId { get; set; }
        public IEnumerable<TrackDTO>? Tracks { get; set; }
        public PageViewModel? Page { get; set; }

        public EditTrackViewModel (IEnumerable<TrackDTO>? tracks, PageViewModel? page)
        {
            Tracks = tracks;
            Page = page;
        }
    }
}
