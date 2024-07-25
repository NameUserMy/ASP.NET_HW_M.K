using HW_7_MusicPortal.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resources;
using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models.FormModels
{
    [Culture]
    public class AddTrackViewModel
    {
        [Required(ErrorMessageResourceType=typeof(Resource),ErrorMessageResourceName = "ChoiseGenre")]
        
        public int? GenreId { get; set; }
        public SelectList? Genre { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ChoiseCategoty")]

        public int? CategoryId { get; set; }
        public SelectList? Category { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ChoisePerformer")]
        public int? PerformerId { get; set; }
        public SelectList? Performer { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ChoiseAlbum")]
        public int? AlbumId { get; set; }
        public SelectList? Album { get; set; }
    }
}
