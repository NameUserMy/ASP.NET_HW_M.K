using Microsoft.AspNetCore.Mvc.Rendering;
using Resources;
using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models.FormModels
{
    public class GenreViewModel
    {
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,10}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "GenreSimbol")]
        public string? Genre { get; set; }

        public string? OptionGenre { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,10}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "GenreSimbol")]
        public string? Category { get; set; }

        public string? OptionCategory { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,20}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PerformerSimbol")]
        public string? Performer { get; set; }

        public string? OptionPerformer { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{3,10}$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "GenreSimbol")]
        public string? Album { get; set; }
        public SelectList? GenriL { get; set; }
        public SelectList? CategoryL { get; set; }
        public SelectList? PerformerL { get; set; }
    }
}
