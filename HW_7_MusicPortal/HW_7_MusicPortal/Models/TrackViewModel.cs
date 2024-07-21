using MusicPortal.BLL.DTO;

namespace HW_7_MusicPortal.Models
{
    public class TrackViewModel
    {
        public IEnumerable<TrackinfoDTO>? SrcTrack {  get; set; }
        public IEnumerable<GenreDTO>? Genres {  get; set; }
        public LinkGenreViewModel? GenresLink { get; set; }
        public TrackViewModel(IEnumerable<GenreDTO> genres, LinkGenreViewModel genresLink)
        {

            Genres = genres;
            GenresLink =genresLink;

        }
    }
}
