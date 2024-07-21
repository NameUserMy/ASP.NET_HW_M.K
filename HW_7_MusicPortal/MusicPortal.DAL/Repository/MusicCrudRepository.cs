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
        public async Task CreateCategoryAsync(Category category)
        {
            await _DB.Categories.AddAsync(category);
        }
        public async Task CreateAlbumAsync(Album album)
        {
           await _DB.Albums.AddAsync( album );
        }
        public async Task CreateTrackAsync(PerformerGTA track)
        {
           
           
            
            await _DB.PerformerGTAs.AddAsync(track);
           
        }
        #endregion



        #region Update Methods
        public Task UpdateAlbumAsync(Album album)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateGenreAsync(Genre genre)
        {
             _DB.Genres.FirstOrDefaultAsync(e=>e.Id==genre.Id).Result.Title=genre.Title;
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
        public Task UpdatePerformerAsync(Performer performer)
        {
            throw new NotImplementedException();
        }
        public Task UpdateTrackkAsync(Track track)
        {
            throw new NotImplementedException();
        }
        public Task UpdateCategoryAsync(Category genre)
        {
            throw new NotImplementedException();
        }

       
        #endregion
     
        #region Delete Method
        public async Task DeleteGenreAsync(int id)
        {
           var targetDelete= await _DB.Genres.FirstOrDefaultAsync(e => e.Id == id);
           _DB.Remove(targetDelete);
        }


        #endregion


        #region Read Method
            public async Task<IEnumerable<SourceTrack>> GetAllSrcTrackAsync()
            {
                 return await Task.Run(()=>_DB.SourceTracks);
            }
        #endregion

        public async Task<string> PathTrack(int IdPerformer, int idGenre, int idCategory, int idAlbum)
        {


            string Path = $"{_DB.Genres.FirstOrDefaultAsync(p => p.Id == idGenre).Result.Title}/" +
                  $"{_DB.Categories.FirstOrDefaultAsync(p => p.Id == idCategory).Result.Title}/" +
                  $"{_DB.Performsers.FirstOrDefaultAsync(p => p.Id == IdPerformer).Result.Name}/" +
                  $"{_DB.Albums.FirstOrDefaultAsync(p => p.Id == idAlbum).Result.Title}";
            return Path;
        }
    }
}
