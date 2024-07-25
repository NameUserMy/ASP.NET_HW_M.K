using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW_7_MusicPortal.Models
{
    public class LanguageViewModel
    {

        public string? Culture {  get; set; }
        public SelectList? Languages { get; set; }
        
    }
}
