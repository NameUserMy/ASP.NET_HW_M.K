using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces
{
    public interface IMusicCrudService
    {
        public Task CreatePerformerAsync(CreateGenreDTO performer);
        public Task CreateGenreAsync(CreateGenreDTO genre);
        public Task CreateCategoryAsync(CreateGenreDTO category);
        public Task CreateTrackAsync(AddTrackDTO track,string src);
        public Task CreateAlbumAsync(CreateGenreDTO album);
        public Task<string> PathTrack(int IdPerformer, int idGenre, int idCategory, int idAlbum);


        public Task UpdateSrcExcute(string srcOld, string srcNew);

        public Task UpdatePerformerAsync(CreateGenreDTO performer);
        public Task UpdateGenreAsync(GenreDTO genre);
        public Task UpdateAlbumAsync(CreateGenreDTO album);
        public Task UpdateTrackkAsync(Track track);

        public Task DeleteGenreAsync(int id);

    }
}
