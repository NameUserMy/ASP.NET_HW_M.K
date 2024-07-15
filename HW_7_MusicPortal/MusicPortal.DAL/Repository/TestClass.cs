using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Repository
{
    internal class TestClass
    {
        PortalContext? _DB;
        public TestClass(PortalContext context)
        {


            _DB = context;

        }


        public void TestSongMy (){


            Performer performer = new Performer();

            performer.Name = "Performer";
            performer.Albums.Append(new Album { Title="Album"});
            performer.Genres.Append(new Genre { Title="Genre"});
            performer.Tracks.Append(new Track { Title="Track"});
            

            _DB.Add(performer);
        
        
        }
    }
}
