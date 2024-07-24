using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO
{
    public class AdminInfoDTO
    {
        public int TracksCount { get; set; }
        public int AlbumsCount { get; set; }
        public int PerformersCount { get; set; }
        public int GenresCount { get; set; }
        public int ForConfarmationsCount { get; set; }
    }
}
