namespace MusicPortal.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? NickName { get; set; }
        public string? Login { get; set; }
        public bool Confirmation {  get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
    }
}
