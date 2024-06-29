using System.ComponentModel.DataAnnotations;

namespace HW__6_GuestBook_IRepository.Models
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
