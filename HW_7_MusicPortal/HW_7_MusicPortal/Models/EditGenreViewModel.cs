using MusicPortal.BLL.DTO;


namespace HW_7_MusicPortal.Models
{
    public class EditGenreViewModel
    {

        public string? GenreTitel { get; set; }
        public int GenreId {  get; set; }
        public PageViewModel? PageViewModelGenre { get; set; }
        public IEnumerable<GenreDTO>? Genres { get; set; }
        public EditGenreViewModel(){}
        public EditGenreViewModel(PageViewModel viewModel,IEnumerable<GenreDTO> genres ) { 
        
            PageViewModelGenre= viewModel;
            Genres= genres;
        
        }
    }
}
