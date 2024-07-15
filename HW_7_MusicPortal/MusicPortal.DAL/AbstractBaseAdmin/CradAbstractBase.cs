using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.AbstractBaseAdmin
{
    public abstract class CradAbstractBase
    {
        public abstract void Delete(int  id);
        public abstract void Update<T>(T value);
        public abstract void Create<T>(T value);
       
    }
}
