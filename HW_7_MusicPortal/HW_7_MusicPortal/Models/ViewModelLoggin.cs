using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models
{
    public class ViewModelLoggin
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set;}
    }
}
