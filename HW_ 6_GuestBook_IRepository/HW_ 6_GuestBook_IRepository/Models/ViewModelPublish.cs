using System.ComponentModel.DataAnnotations;

namespace HW__6_GuestBook_IRepository.Models
{
    public class ViewModelPublish
    {
        [Required]
        [StringLength(15)]
        [RegularExpression(@"[?!,.a-z,A-Zа-я,А-ЯёЁ,0-9\s]{1,15}", ErrorMessage = "Только буквы цыфры .!,")]
        public string? Theme { get; set; }

        [Required]
        [StringLength(150)]
        [RegularExpression(@"[?!,.a-z,A-Zа-я,А-ЯёЁ,0-9,\s]{1,150}", ErrorMessage = "Только буквы цыфры .!,")]
        public string? Message { get; set; }
    }
}
