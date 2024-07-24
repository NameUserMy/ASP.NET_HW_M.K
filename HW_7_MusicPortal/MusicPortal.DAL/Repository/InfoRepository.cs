using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.DAL.Repository
{
    public class InfoRepository : IInformation
    {

        PortalContext? _DB;
        public InfoRepository(PortalContext context)
        {
            _DB = context;
        }


        #region Get All Methods

        public async Task<IEnumerable<Album>> GetAllAlbumAsync()
        {
            return await Task.Run(()=>_DB.Albums); 
        }
        public async Task<IEnumerable<Performer>> GetAllPerformerAsync()
        {
            return await Task.Run(() => _DB.Performsers);
        }
        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await Task.Run(() => _DB.Categories);
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            return await Task.Run(() => _DB.Genres);
        }
        #endregion
        public async Task<Genre> GetGenreAsync(int idGenre)
        {
             return await _DB.Genres.FirstOrDefaultAsync(e=>e.Id==idGenre);
        }

       

        public async Task<IEnumerable<User>> GetConfirmUser()
        {
            return await Task.Run(() => _DB.Users.Where(u => u.Confirmation == true));
        }

        public async Task<IEnumerable<User>> GetNotConfirmUser()
        {
            return await Task.Run(()=> _DB.Users.Where(u => u.Confirmation == false));
        }

        public async Task<IEnumerable<SourceTrack>> GetAllSrcTrackAsync()
        {
            return await Task.Run(() => _DB.SourceTracks);
        }

        public async Task<IEnumerable<Performer>> GetInfoForTrack()
        {
            return await Task.Run(()=>_DB.Performsers.Include(e => e.Tracks).ThenInclude(e=>e.Source));

          
        }

        public async Task<IEnumerable<SourceTrack>> GetInfoTrackByLikeAsync(string like)
        {

           return await Task.Run(() => _DB.SourceTracks.Where(e=>e.Src.Contains(like)).Include(e => e.Track).ThenInclude(e=>e.Performers));

           
        }

        public async Task<IEnumerable<Track>> GetAllTrackAsync()
        {
            return await Task.Run(() => _DB.Tracks.Include(p=>p.Performers));
        }

        public async Task<Track> GetTrackAsync(int idTrack)
        {
            return await _DB.Tracks.FirstOrDefaultAsync(e => e.Id == idTrack);
        }
    }
}
