using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPortal.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models
{
    public class GenreFormModel
    {
       
        public string? Genre { get; set; }

        public string? OptionGenre { get; set; }
        public string? Category { get; set; }

        public string? OptionCategory { get; set; }
        public string? Performer { get; set; }

        public string? OptionPerformer { get; set; }
        public string? Album { get; set; }
    }
}
