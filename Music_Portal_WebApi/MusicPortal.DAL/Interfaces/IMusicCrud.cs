﻿using MusicPortal.DAL.Entities;


namespace MusicPortal.DAL.Interfaces
{
    public interface IMusicCrud
    {
        #region Create
        public Task CreatePerformerAsync(Performer performer);
        public Task CreateGenreAsync(Genre genre);
        public Task CreateTrackAsync(PerformerGTA track);
        #endregion

        #region Update Method
        public Task UpdateSrcExcute(string srcOld, string srcNew);
        public Task UpdatePerformerAsync(Performer performer);
        public Task UpdateGenreAsync(Genre genre);
        public Task UpdateTrackAsync(Track track);
        public Task UpdateSourceAsync(SourceTrack srcTrack);
        #endregion

        #region Delete Method
        public Task DeleteGenreAsync(int id);
        public Task DeletePerformerAsync(int id);
        public Task DeleteTrackAsync(int id);
        #endregion
       
        #region Read Method
        public Task<IEnumerable<SourceTrack>> GetAllSrcTrackAsync();
        public Task<IEnumerable<Track>> GetAllTrackAsync();
        public Task<Track> GetTrackByIdAsync(int id);
        public Task<IEnumerable<Genre>> GetAllGenreAsync();
        public Task<Genre> GetGenreByIdAsync(int id);
        public Task<IEnumerable<Performer>> GetAllPerformerAsync();
        public Task<Performer> GetPerformerByIdAsync(int id);
        #endregion


        public Task<string> PathTrack(int IdPerformer, int idGenre);

    }
}
