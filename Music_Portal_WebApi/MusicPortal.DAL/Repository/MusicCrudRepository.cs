using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.DAL.Repository
{
    public class MusicCrudRepository : IMusicCrud
    {

        private PortalContext? _DB;

        public MusicCrudRepository(PortalContext context ) {

            _DB = context;
        
        }
        #region Create Method
        public async Task CreatePerformerAsync(Performer performer)
        {
            await _DB.Performsers.AddAsync(performer);
        }
        public async Task CreateGenreAsync(Genre genre)
        {
            await _DB.Genres.AddAsync(genre);
        }
        public async Task CreateTrackAsync(PerformerGTA track )
        {
    
            await _DB.PerformerGTAs.AddAsync(track);
           
        }
        #endregion



        #region Update Methods
      
        public async Task UpdateGenreAsync(Genre genre)
        {
            if (_DB != null)
            {
                var targeUpdate = await _DB.Genres.SingleOrDefaultAsync(u => u.Id == genre.Id);

                if (targeUpdate != null)
                {
                   targeUpdate.Title= genre.Title;
                }
                else
                {

                    throw new Exception("User not found");
                }
            }
            else
            {
                throw new NullReferenceException("Somthin wrone, NullReference!");
            }
        }
        public async Task UpdateTrackAsync(Track track)
        {
            if (_DB != null)
            {
                var targeUpdate = await _DB.Tracks.SingleOrDefaultAsync(u => u.Id == track.Id);

                if (targeUpdate != null)
                {
                    targeUpdate.Title=track.Title;
                }
                else
                {

                    throw new Exception("User not found");
                }
            }
            else
            {
                throw new NullReferenceException("Somthin wrone, NullReference!");
            }

        }
        public async Task UpdatePerformerAsync(Performer performer)
        {
            if (_DB != null)
            {
                var targeUpdate = await _DB.Performsers.SingleOrDefaultAsync(u => u.Id == performer.Id);

                if (targeUpdate != null)
                {
                    targeUpdate.Name = performer.Name;
                    targeUpdate.Description = performer.Description;
                }
                else
                {

                    throw new Exception("User not found");
                }
            }
            else
            {
                throw new NullReferenceException("Somthin wrone, NullReference!");
            }
        }
        public async Task UpdateSourceAsync(SourceTrack srcTrack)
        {
            _DB.SourceTracks.FirstOrDefaultAsync(e => e.Id == srcTrack.Id).Result.Src = srcTrack.Src;
        }
        public async Task UpdateSrcExcute(string srcOld, string srcNew)
        {

            await _DB.SourceTracks.Where(e => e.Src.Contains(srcOld))
            .ExecuteUpdateAsync(s => s.SetProperty(a => a.Src, a => a.Src.Replace(srcOld, srcNew)));




        }
      
        #endregion

        #region Delete Method
        public async Task DeletePerformerAsync(int id)
        {
            var targetDelete = await _DB.Performsers.FirstOrDefaultAsync(e => e.Id == id);
            _DB.Remove(targetDelete);
        }
        public async Task DeleteGenreAsync(int id)
        {
           var targetDelete= await _DB.Genres.FirstOrDefaultAsync(e => e.Id == id);
           _DB.Remove(targetDelete);
        }
        public async Task DeleteTrackAsync(int id)
        {
            var targetDelete = await _DB.Tracks.FirstOrDefaultAsync(e => e.Id == id);
            _DB.Remove(targetDelete);
        }
      
        #endregion


        #region Read Method
        public async Task<IEnumerable<SourceTrack>> GetAllSrcTrackAsync()
            {
                 return await Task.Run(()=>_DB.SourceTracks);
            }
        public async Task<IEnumerable<Track>> GetAllTrackAsync()
        {
            return await Task.Run(()=>_DB.Tracks);
        }

        public async Task<Track> GetTrackByIdAsync(int id)
        {
            return await _DB.Tracks.SingleOrDefaultAsync(t=>t.Id==id);
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            return await Task.Run(() => _DB.Genres);
        }
    

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _DB.Genres.SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Performer>> GetAllPerformerAsync()
        {
            return await Task.Run(() => _DB.Performsers);
        }

        public async Task<Performer> GetPerformerByIdAsync(int id)
        {
            return await _DB.Performsers.SingleOrDefaultAsync(p => p.Id == id);
        }
        #endregion

        public async Task<string> PathTrack(int IdPerformer, int idGenre)
        {


            string Path = $"{_DB.Genres.FirstOrDefaultAsync(p => p.Id == idGenre).Result.Title}/" +
                  $"{_DB.Performsers.FirstOrDefaultAsync(p => p.Id == IdPerformer).Result.Name}/";
            return Path;
        }
    }
}
