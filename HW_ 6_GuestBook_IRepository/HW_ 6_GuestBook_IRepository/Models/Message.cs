using System.Reflection.Metadata;

namespace HW__6_GuestBook_IRepository.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string? Theme { get; set; }
        public string? UserMessage { get; set; }
        public DateTime? DOP { get; set;}
        public int UserId { get; set; } 
        public User  User { get; set; } = null!; 
    }
}
