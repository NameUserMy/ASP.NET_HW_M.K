using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Entities;


namespace MusicPortal.BLL.Interfaces
{
    public interface IInformationService
    {
        public Task<IEnumerable<NotConfirmUserDTO>> GetNotConfirmUser();
        public Task<IEnumerable<ConfirmUserDTO>> GetConfirmUser();
        public Task<IEnumerable<Album>> GetAlbums();
        public Task<IEnumerable<Performer>> GetAllPerformerAsync();
        public Task<IEnumerable<GenreDTO>> GetAllGenreAsync();
        public Task<GenreDTO> GetGenreAsync(int idGenre);
        public Task<IEnumerable<Category>> GetAllCategoryAsync();
        public Task<IEnumerable<TrackinfoDTO>> GetInfoForTrack();

        public Task<IEnumerable<TrackinfoDTO>> GetInfoTrackByLikeAsync(string like);
    }
}
