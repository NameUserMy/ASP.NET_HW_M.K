namespace HW__6_GuestBook_IRepository.Models
{
    public class ViewModelMessage
    {
       public IEnumerable<Message>? Messages { get; }
        public PageViewModel? PageViewModel { get; }
        public ViewModelMessage(IEnumerable<Message> message, PageViewModel pageViewModel) { 
        
            Messages= message;
            PageViewModel= pageViewModel;
        
        }



    }
}
