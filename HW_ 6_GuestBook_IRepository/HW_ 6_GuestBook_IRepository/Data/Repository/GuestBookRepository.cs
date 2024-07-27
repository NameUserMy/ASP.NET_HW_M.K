using AutoMapper;
using HW__6_GuestBook_IRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace HW__6_GuestBook_IRepository.Data.Repository
{
    public class GuestBookRepository : IRepository
    {
        private readonly GuestBookContext? _context;
        public GuestBookRepository(GuestBookContext context) {
        
        _context = context;
        
        }

        public async Task CreateMessageAsync(Message message, string login)
        {
            var user=await _context.Users.FirstOrDefaultAsync(l=>l.Login== login);
            user.Messages.Add( message); 
                          
        }

        public async Task CreateUserAsync(User user)
        {
           await _context.AddAsync(user);
        }

        public async Task<bool> IsLoginAsync(string loggin)
        {
            if (await _context.Users.FirstOrDefaultAsync(l => l.Login == loggin) != null)
            {
                return false;

            };

            return true;
            
        }
        public async Task<bool> IsNickNameAsync(string nickName)
        {
            if (await _context.Users.FirstOrDefaultAsync(l => l.NickName == nickName) != null)
            {
                return false;

            };

            return true;
        }

        public async Task<IEnumerable<Message>> GetAllMessageAsync()
        {
   
            return await Task.Run(()=> _context.messages.Include(messages => messages.User));
        }

     
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByLogginAsync(string loggin)
        {
           return await  _context.Users.FirstOrDefaultAsync(l => l.Login == loggin);
            
        }

        public async Task<IEnumerable<MessageAjax>> GetAllViewMessageAsync()
        {
            var conf = new MapperConfiguration(conf => conf.CreateMap<Message, MessageAjax>()
            .ForMember("NickName",e=>e.MapFrom(e=>e.User.NickName)));
            var mapper = new Mapper(conf);
            return mapper.Map<IEnumerable<Message>, IEnumerable<MessageAjax>>(await Task.Run(()=>_context.messages.Include(messages => messages.User)));
        }
    }
}
