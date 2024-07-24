using MusicPortal.BLL.DTO;

namespace HW_7_MusicPortal.Models
{
    public class TrackViewModel
    {
        public IEnumerable<TrackinfoDTO>? SrcTrack {  get; set; }
        public IEnumerable<GenreDTO>? Genres {  get; set; }
        public IEnumerable<PerformerDTO>? Performers {  get; set; }
        public IEnumerable<AlbumDTO>? Albums {  get; set; }

        public PageViewModel? AlbumsLink { get; set; }
        public PageViewModel? PerformerLink { get; set; }
        public PageViewModel? GenresLink { get; set; }
        public PageViewModel? PageTrackL { get; set; }
        public bool? OrderBy { get; set; }
        public TrackViewModel(IEnumerable<GenreDTO> genres, PageViewModel genresLink, 
            IEnumerable<PerformerDTO> performer, PageViewModel performerLink, IEnumerable<AlbumDTO> album, PageViewModel albuLink,
            IEnumerable<TrackinfoDTO> track, PageViewModel pageTrackL,bool order)
        {

            SrcTrack=track;
            PageTrackL=pageTrackL;

            Albums = album;
            AlbumsLink = albuLink;
            OrderBy = order;
            Genres = genres;
            GenresLink =genresLink;
            PerformerLink =performerLink;
            Performers = performer;

        }
    }
}
