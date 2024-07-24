using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models.FormModels
{
    public class AddTrackViewModel
    {
        [Required(ErrorMessage = "(Choise Genre)")]
        public int? GenreId { get; set; }
        public SelectList? Genre { get; set; }
        [Required(ErrorMessage = "(Choise Category)")]
        public int? CategoryId { get; set; }
        public SelectList? Category { get; set; }
        [Required(ErrorMessage = "(Choise Performer)")]
        public int? PerformerId { get; set; }
        public SelectList? Performer { get; set; }
        [Required(ErrorMessage = "(Choise Album)")]
        public int? AlbumId { get; set; }
        public SelectList? Album { get; set; }
    }
}
