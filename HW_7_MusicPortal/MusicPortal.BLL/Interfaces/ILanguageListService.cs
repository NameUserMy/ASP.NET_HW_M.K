using MusicPortal.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces
{
    public interface ILanguageListService
    {
       public List<LLDTO> LanguageList();
    }
}
