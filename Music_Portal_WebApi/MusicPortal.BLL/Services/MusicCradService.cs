using AutoMapper;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Services
{
    internal class MusicCradService : IMusicCradService
    {


        private IUnitOfWork DB { get; set; }
        public MusicCradService(IUnitOfWork unit)
        {
            DB = unit;

        }
        #region Create method
        public async Task CreateGenreAsync(GenreDTO genre)
        {
           await DB.MusicCrudRepository.CreateGenreAsync(new Genre {
            
                Title = genre.Title,
            });

           await DB.SaveAsync();
        }
        public async Task CreatePerformerAsync(PerformerDTO performer)
        {
           await DB.MusicCrudRepository.CreatePerformerAsync(new Performer {Name=performer.Name,Description=performer.Description });
           await DB.SaveAsync(); 
        }
        public async Task CreateTrackAsync(TrackDTO track, int idGenre, int idPerformer, string src)
        {
           await DB.MusicCrudRepository.CreateTrackAsync(new PerformerGTA
           {
               GenreId = idGenre,
               PerformerId = idPerformer,
               Track=new Track { Title=track.Title,Source=new SourceTrack {Src=src}},



           });
           await DB.SaveAsync();
        }
        #endregion

        #region Delete Method
        public async Task DeleteGenreAsync(int id)
        {
            await DB.UserCrudRepository.DeleteUserAsync(id);
            await DB.SaveAsync();
        }

        public async Task DeletePerformerAsync(int id)
        {
            await DB.MusicCrudRepository.DeletePerformerAsync(id);
            await DB.SaveAsync();
        }

        public async Task DeleteTrackAsync(int id)
        {
            await DB.MusicCrudRepository.DeleteTrackAsync(id);
            await DB.SaveAsync();
        }
        #endregion

        #region Read Method
        public async Task<IEnumerable<GenreDTO>> GetAllGenreAsync()
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<Genre, GenreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(await DB.MusicCrudRepository.GetAllGenreAsync());
        }
        public async Task<IEnumerable<PerformerDTO>> GetAllPerformerAsync()
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<Performer, PerformerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Performer>, IEnumerable<PerformerDTO>>(await DB.MusicCrudRepository.GetAllPerformerAsync());
        }
        public async Task<IEnumerable<TrackDTO>> GetAllTrackAsync()
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<Track, TrackDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackDTO>>(await DB.MusicCrudRepository.GetAllTrackAsync());
        }
        public async Task<GenreDTO> GetGenreByIdAsync(int id)
        {
            var genre = await DB.MusicCrudRepository.GetGenreByIdAsync(id);
            return new GenreDTO() {Title= genre.Title};
        }
        public async Task<PerformerDTO> GetPerformerByIdAsync(int id)
        {
            var performer = await DB.MusicCrudRepository.GetPerformerByIdAsync(id);
            return new PerformerDTO() { Name = performer.Name,Description=performer.Description};
        }

        public async Task<TrackDTO> GetTrackByIdAsync(int id)
        {
            var track = await DB.MusicCrudRepository.GetTrackByIdAsync(id);
            return new TrackDTO() {Title= track.Title};
        }
        public Task<IEnumerable<SourceTrack>> GetAllSrcTrackAsync()
        {
            throw new NotImplementedException();
        }
     
        #endregion

        #region Update Method
        public async Task UpdateGenreAsync(GenreDTO genre)
        {
            await DB.MusicCrudRepository.UpdateGenreAsync(new Genre
            {
               Id=genre.Id,
               Title=genre.Title,
            });

            await DB.SaveAsync();
        }

        public async Task UpdatePerformerAsync(PerformerDTO performer)
        {
            await DB.MusicCrudRepository.UpdatePerformerAsync(new Performer
            {
                Id = performer.Id,
                Name = performer.Name,
                Description = performer.Description,


            });

           await DB.SaveAsync();    
        }
        public async Task UpdateTrackAsync(TrackDTO track)
        {
            await DB.MusicCrudRepository.UpdateTrackAsync(new Track
            {
                Id = track.Id,
                Title = track.Title,

            });

            await DB.SaveAsync();
        }

        public Task UpdateSourceAsync(SourceTrack srcTrack)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSrcExcute(string srcOld, string srcNew)
        {
            throw new NotImplementedException();
        }

      
        #endregion
    }


}
