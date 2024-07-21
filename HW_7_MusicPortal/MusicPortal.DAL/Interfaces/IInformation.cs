using MusicPortal.DAL.Entities;

namespace MusicPortal.DAL.Interfaces
{
    public interface IInformation
    {
        public Task <IEnumerable<User>> GetConfirmUser();
        public Task<IEnumerable<User>> GetNotConfirmUser();

        #region Get Method
        public Task<IEnumerable<Genre>> GetAllGenreAsync();
        public Task<Genre> GetGenreAsync(int idGenre);
        public Task<IEnumerable<Performer>> GetAllPerformerAsync();
        public Task<IEnumerable<Category>> GetAllCategoryAsync();
        public Task<IEnumerable<Album>> GetAllAlbumAsync();
        public Task<IEnumerable<SourceTrack>> GetAllSrcTrackAsync();
        public Task<IEnumerable<Performer>> GetInfoForTrack();

        #endregion


        public Task<IEnumerable<SourceTrack>> GetInfoTrackByLikeAsync(string like);
    }
}
