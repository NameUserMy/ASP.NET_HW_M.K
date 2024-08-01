using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces
{
    public interface IMusicCradService
    {
        #region Create
        public Task CreatePerformerAsync(PerformerDTO performer);
        public Task CreateGenreAsync(GenreDTO genre);
        public Task CreateTrackAsync(TrackDTO track,int idGenre,int idPerformer,string src);
        #endregion

        #region Update Method
        public Task UpdateSrcExcute(string srcOld, string srcNew);
        public Task UpdatePerformerAsync(PerformerDTO performer);
        public Task UpdateGenreAsync(GenreDTO genre);
        public Task UpdateTrackAsync(TrackDTO track);
        public Task UpdateSourceAsync(SourceTrack srcTrack);
        #endregion

        #region Delete Method
        public Task DeleteGenreAsync(int id);
        public Task DeletePerformerAsync(int id);
        public Task DeleteTrackAsync(int id);
        #endregion

        #region Read Method
        public Task<IEnumerable<SourceTrack>> GetAllSrcTrackAsync();
        public Task<IEnumerable<TrackDTO>> GetAllTrackAsync();
        public Task<TrackDTO> GetTrackByIdAsync(int id);
        public Task<IEnumerable<GenreDTO>> GetAllGenreAsync();
        public Task<GenreDTO> GetGenreByIdAsync(int id);
        public Task<IEnumerable<PerformerDTO>> GetAllPerformerAsync();
        public Task<PerformerDTO> GetPerformerByIdAsync(int id);
        #endregion
    }
}
