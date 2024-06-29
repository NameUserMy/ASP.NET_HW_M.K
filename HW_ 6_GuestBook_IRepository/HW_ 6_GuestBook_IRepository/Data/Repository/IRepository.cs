using HW__6_GuestBook_IRepository.Models;

namespace HW__6_GuestBook_IRepository.Data.Repository
{
    public interface IRepository
    {
        Task<IQueryable<Message>> GetAllMessageAsync();
        Task<User> GetUserByLogginAsync(string loggin);
        Task CreateUserAsync(User user);
        Task CreateMessageAsync(Message message,string login);
        Task<bool> IsLoginAsync(string loggin);
        Task<bool> IsNickNameAsync(string nickName);
        Task SaveChangeAsync();
    }
}
