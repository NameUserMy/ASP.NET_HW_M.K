using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models.FormModels
{
    public class GenreViewModel
    {
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,20}$", ErrorMessage = "(min 3  max 10 letters)")]
        public string? Genre { get; set; }

        public string? OptionGenre { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,20}$", ErrorMessage = "(min 3  max 10 letters)")]
        public string? Category { get; set; }

        public string? OptionCategory { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,20}$", ErrorMessage = "(min 3  max 20 letters)")]
        public string? Performer { get; set; }

        public string? OptionPerformer { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{3,20}$", ErrorMessage = "(min 3  max 20 letters)")]
        public string? Album { get; set; }
        public SelectList? GenriL { get; set; }
        public SelectList? CategoryL { get; set; }
        public SelectList? PerformerL { get; set; }
    }
}
