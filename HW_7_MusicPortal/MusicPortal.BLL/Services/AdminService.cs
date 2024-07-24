using HW_7_MusicPortal.Services;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.AbstractBaseAdmin;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;

namespace MusicPortal.BLL.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork DB { get; set; }
        public AdminService(IUnitOfWork unit)
        {
            DB = unit;
          
        }
        public void Delete(CradAbstractBase crad, int id)
        {
            crad.Delete(id);
            DB.SaveAsync();
        }

        public void Create(CradAbstractBase crad,ConfirmUserDTO user)
        {
            crad.Create(new User {Login=user.Login,NickName=user.NickName,Password=user.Password,Salt=user.Salt});
        }

        public void ConfirmUser(CradAbstractBase crad,int id)
        {
            crad.Update(new User { Id = id, Confirmation = true});
            DB.SaveAsync();
        }

        public void BlockUser(CradAbstractBase crad, int id)
        {
            crad.Update(new User { Id = id, Confirmation = false });
            DB.SaveAsync();
        }

        #region Create Music Method
        public async Task CreatePerformerAsync(CreateGenreDTO performer)
        {
            DB.MusicCrudRepository.CreatePerformerAsync(new Performer { Name = performer.Performer });
            await DB.SaveAsync();
        }
        public async Task CreateGenreAsync(CreateGenreDTO genre)
        {
            DB.MusicCrudRepository.CreateGenreAsync(new Genre { Title = genre.Genre });
            await DB.SaveAsync();
        }
        public async Task CreateCategoryAsync(CreateGenreDTO category)
        {
            DB.MusicCrudRepository.CreateCategoryAsync(new Category { Title = category.Category });
            await DB.SaveAsync();
        }
        public async Task CreateAlbumAsync(CreateGenreDTO album)
        {
            DB.MusicCrudRepository.CreateAlbumAsync(new Album { Title=album.Album});
            await DB.SaveAsync();
        }
        public async Task CreateTrackAsync(AddTrackDTO track,string src)
        {
           await DB.MusicCrudRepository.CreateTrackAsync(new PerformerGTA {
               AlbumId=track.IdAlbum,
               CategoryId=track.IdCategory,
               GenreId=track.IdGenre,
               PerformerId=track.IdPerformer,
               Track=new Track { Title=track.TrackTitle,Source=new SourceTrack {Src= src} }
           });
          await  DB.SaveAsync();
           
        }
        #endregion
        public Task UpdatePerformerAsync(CreateGenreDTO performer)
        {
            throw new NotImplementedException();
        }

        #region Update Method
        public async Task UpdateGenreAsync(GenreDTO genre)
        {
            await DB.MusicCrudRepository.UpdateGenreAsync(new Genre { Id=genre.Id,Title=genre.Title});
            await DB.SaveAsync();
        }
        public async Task UpdateTrackkAsync(TrackDTO track)
        {
            await DB.MusicCrudRepository.UpdateTrackkAsync(new Track { Id = track.Id, Title = track.Title });
            await DB.SaveAsync();
        }
        public Task UpdateAlbumAsync(CreateGenreDTO album)
        {
            throw new NotImplementedException();
        }
        public Task UpdateTrackkAsync(Track track)
        {
            throw new NotImplementedException();
        }
        #endregion

        public async Task<string> PathTrack(int IdPerformer, int idGenre, int idCategory, int idAlbum)
        {
          return await  DB.MusicCrudRepository.PathTrack( IdPerformer,idGenre,idCategory,idAlbum);
        }
        public async Task UpdateSrcExcute(string srcOld, string srcNew)
        {
            await DB.MusicCrudRepository.UpdateSrcExcute(srcOld,srcNew);
        }
        #region Delete Method
        public async Task DeleteGenreAsync(int id)
        {
           await DB.MusicCrudRepository.DeleteGenreAsync(id);
           await DB.SaveAsync();
        }

        public async Task DeleteTrackAsync(int id)
        {
            await DB.MusicCrudRepository.DeleteTrackAsync(id);
            await DB.SaveAsync();
        }
        #endregion

    }
}
