using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW_4_Top_10_CRUD.Models
{
    public class AllInfoModelView
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Obligatory field")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "min(3) max(20) simbol")]
        public string? Title { get; set; }

        [StringLength(50, ErrorMessage = "max(50) simbol")]
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "Obligatory field")]
        [DataType(DataType.Date)]
        public DateOnly? Year { get; set; }

        [Required(ErrorMessage = "Obligatory field")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "min(3) max(20) simbol")]
        public string? Genre { get; set; }

        public string? PosterUrl { get; set; }


        [DataType(DataType.Time)]
        public TimeOnly? Runtime { get; set; }


        [StringLength(35, ErrorMessage = " max(35) simbol")]
        public string? Director { get; set; }


        [StringLength(50, ErrorMessage = " max(50) simbol")]
        public string? Actors { get; set; }

       
        [StringLength(50, ErrorMessage = " max(50) simbol")]
        public string? Language { get; set; }
    }
}
