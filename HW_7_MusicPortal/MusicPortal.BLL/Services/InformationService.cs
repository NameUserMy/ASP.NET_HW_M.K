using AutoMapper;

using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;
using System.Linq;

namespace MusicPortal.BLL.Services
{
    public class InformationService : IInformationService
    {

        private IUnitOfWork DB { get; set; }
        public InformationService(IUnitOfWork unit)
        {
            DB = unit;
            
        }

        public async Task<IEnumerable<NotConfirmUserDTO>> GetNotConfirmUser()
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<User, NotConfirmUserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<NotConfirmUserDTO>>(await DB.Information.GetNotConfirmUser());
        }

        public async Task<IEnumerable<ConfirmUserDTO>> GetConfirmUser()
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<User, ConfirmUserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<ConfirmUserDTO>>(await DB.Information.GetConfirmUser());
        }

        public async Task<IEnumerable<AlbumDTO>> GetAllAlbums()
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<Album, AlbumDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDTO>>(await DB.Information.GetAllAlbumAsync());
        }

        public async Task<IEnumerable<PerformerDTO>> GetAllPerformerAsync()
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<Performer, PerformerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Performer>, IEnumerable<PerformerDTO>>(await DB.Information.GetAllPerformerAsync());

           
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenreAsync()
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<Genre, GenreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(await DB.Information.GetAllGenreAsync());
        }
        public async Task<GenreDTO> GetGenreAsync(int idGenre)
        {
            var genre= await DB.Information.GetGenreAsync(idGenre);


            return new GenreDTO { Id = genre.Id, Title = genre.Title }; 
        }
        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await DB.Information.GetAllCategoryAsync();
        }
        public async Task<IEnumerable<TrackDTO>> GetAllTrackAsync()
        {

            List<TrackDTO>? infoTrack = new List<TrackDTO>();


            foreach (var item in  await DB.Information.GetAllTrackAsync())
            {
                foreach (var dscTrack in item.Performers)
                {

                    infoTrack.Add(new TrackDTO
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Performer = dscTrack.Name


                    });

                }

            }
            return infoTrack;
        }


        public async Task<IEnumerable<TrackinfoDTO>> GetInfoForTrack()
        {

            List<TrackinfoDTO>? infoTrack=new List<TrackinfoDTO>();


            foreach (var item in await DB.Information.GetInfoForTrack())
            {
                foreach (var dscTrack in item.Tracks)
                {

                    infoTrack.Add(new TrackinfoDTO
                    {

                        performer = item.Name,
                        Title = dscTrack.Title,
                        Src = dscTrack.Source.Src

                    });

                }

            }



            return infoTrack;
        }

        public async Task<IEnumerable<TrackinfoDTO>> GetInfoTrackByLikeAsync(string like)
        {




            List<TrackinfoDTO>? infoTrack = new List<TrackinfoDTO>();


            foreach (var item in await DB.Information.GetInfoTrackByLikeAsync(like))
            {
                foreach (var dscTrack in item.Track.Performers)
                {

                    infoTrack.Add(new TrackinfoDTO
                    {

                        performer = dscTrack.Name,
                        Title = item.Track.Title,
                        Src = item.Src

                    });

                }

            }



            return infoTrack;




            
        }

        public async Task<AdminInfoDTO> GetAllInfoForBoard()
        {
            AdminInfoDTO adminInfo = new AdminInfoDTO();

            await Task.Run(() =>
            {
                adminInfo.TracksCount = DB.Information.GetAllSrcTrackAsync().Result.Count();
                adminInfo.AlbumsCount = DB.Information.GetAllAlbumAsync().Result.Count();
                adminInfo.GenresCount = DB.Information.GetAllGenreAsync().Result.Count();
                adminInfo.PerformersCount = DB.Information.GetAllPerformerAsync().Result.Count();
                adminInfo.ForConfarmationsCount = DB.Information.GetNotConfirmUser().Result.Count();
            });
            return adminInfo;
        }

        public async Task<TrackDTO> GetTrackAsync(int idTrack)
        {

            var targetTrack = await DB.Information.GetTrackAsync(idTrack);

           return  new TrackDTO {Id=targetTrack.Id,Title=targetTrack.Title};
        }
    }
}
