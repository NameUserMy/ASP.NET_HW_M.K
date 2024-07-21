using MusicPortal.BLL.DTO;

namespace HW_7_MusicPortal.Models
{
    public class EditGenreViewModel
    {

        public string? GenreTitel { get; set; }
        public int GenreId {  get; set; }
        public IEnumerable<GenreDTO>? Genre { get; set; }
    }
}
