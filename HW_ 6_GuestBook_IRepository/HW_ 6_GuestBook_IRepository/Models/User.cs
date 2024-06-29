using Microsoft.Extensions.Hosting;

namespace HW__6_GuestBook_IRepository.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? NickName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set;}
        public string? Salt { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
