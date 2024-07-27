namespace HW__6_GuestBook_IRepository.Models
{
    public class ViewModelMessage
    {
       public IEnumerable<MessageAjax>? Messages { get; }
      
        public PageViewModel? PageViewModel { get; }
        public ViewModelMessage() { }
        public ViewModelMessage(IEnumerable<MessageAjax> message, PageViewModel pageViewModel) { 
        
            Messages= message;
            PageViewModel= pageViewModel;
        
        }



    }
}
