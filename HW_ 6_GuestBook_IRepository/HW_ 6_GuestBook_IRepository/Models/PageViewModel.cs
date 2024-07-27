using HW__6_GuestBook_IRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace HW__6_GuestBook_IRepository.Models
{
    public class PageViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageNumber>1;
        public bool NextPage => PageNumber < TotalPages;

        public PageViewModel(int count,int pageNumber,int pageSize) {

            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize);
        
        }
    }
}
//List<MessageViewModel> messages = new List<MessageViewModel>();

//var resultMessage = await Task.Run(() => _context.messages.Include(messages => messages.User).AsEnumerable());

//foreach (var message in resultMessage)
//{
//    messages.Add(new MessageViewModel
//    {

//        UserName = message.User.NickName,
//        Message = message.UserMessage,
//        Theme = message.Theme,
//        DOP = message.DOP.ToString(),
//    });
//}