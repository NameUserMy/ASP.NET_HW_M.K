using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string? NickName { get; set; }
        public string? Login { get; set; }
        public bool Confirmation { get; set; }
       
    }
}
