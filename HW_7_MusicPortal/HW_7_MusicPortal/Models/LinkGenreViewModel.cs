namespace HW_7_MusicPortal.Models
{
    public class LinkGenreViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool NextPage => PageNumber < TotalPages;

        public LinkGenreViewModel(int count, int pageNumber, int pageSize)
        {

            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        }
    }
}
