using AutoMapper;

using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;

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
    }
}
