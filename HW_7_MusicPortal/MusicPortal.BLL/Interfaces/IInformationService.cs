using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Entities;


namespace MusicPortal.BLL.Interfaces
{
    public interface IInformationService
    {
        
        
       
        public Task<IEnumerable<PerformerDTO>> GetAllPerformerAsync();
        public Task<IEnumerable<GenreDTO>> GetAllGenreAsync();
        public Task<IEnumerable<Category>> GetAllCategoryAsync();
        public Task<IEnumerable<AlbumDTO>> GetAllAlbums();
        public Task<IEnumerable<TrackDTO>> GetAllTrackAsync();

        public Task <AdminInfoDTO> GetAllInfoForBoard();



        public Task<GenreDTO> GetGenreAsync(int idGenre);
        public Task<TrackDTO> GetTrackAsync(int idTrack);
        public Task<IEnumerable<TrackinfoDTO>> GetInfoForTrack();
        public Task<IEnumerable<ConfirmUserDTO>> GetConfirmUser();
        public Task<IEnumerable<NotConfirmUserDTO>> GetNotConfirmUser();
        public Task<IEnumerable<TrackinfoDTO>> GetInfoTrackByLikeAsync(string like);
    }
}
