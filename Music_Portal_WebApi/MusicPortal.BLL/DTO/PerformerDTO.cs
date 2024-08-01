using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO
{
    public class PerformerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GenreId { get; set; }
        public string? Description { get; set; }
    }
}
