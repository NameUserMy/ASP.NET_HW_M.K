using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Interfaces
{
    public interface IMusicCrud
    {
        #region Create
        public Task CreatePerformerAsync(Performer performer);
        public Task CreateGenreAsync(Genre genre);
        public Task CreateCategoryAsync(Category category);
        public Task CreateAlbumAsync(Album album);
        public Task CreateTrackAsync(PerformerGTA track);
        #endregion

        #region Update Method
        public Task UpdateSrcExcute(string srcOld, string srcNew);
        public Task UpdatePerformerAsync(Performer performer);
        public Task UpdateGenreAsync(Genre genre);
        public Task UpdateCategoryAsync(Category genre);
        public Task UpdateAlbumAsync(Album album);
        public Task UpdateTrackkAsync(Track track);
        public Task UpdateSourceAsync(SourceTrack srcTrack);
        #endregion

        #region Delete Method
        public Task DeleteGenreAsync(int id);
        #endregion
        #region Read Method

        public Task<IEnumerable<SourceTrack>> GetAllSrcTrackAsync();


        #endregion


        public Task<string> PathTrack(int IdPerformer, int idGenre, int idCategory, int idAlbum);

    }
}
