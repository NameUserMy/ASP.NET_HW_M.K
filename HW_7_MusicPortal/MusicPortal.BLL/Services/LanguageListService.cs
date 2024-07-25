using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Services
{
    public class LanguageListService : ILanguageListService
    {


        private IConfiguration? _configuration;
        private List<LLDTO>? _languages;
        private IConfigurationSection _getSection;
        private string? _targetSection;
        private readonly ILogger<LanguageListService> _logger;


       


        public LanguageListService(IConfiguration configuration, ILogger<LanguageListService> logger ) { 
          
            _logger = logger;
            _configuration = configuration;
            _targetSection = "Lang";
            _getSection = _configuration.GetSection(_targetSection);
           
            
        }


        public List<LLDTO> LanguageList(){
            return  GetlidtLanguage();
        }
        
        private List<LLDTO> GetlidtLanguage()
        {
            _languages = new List<LLDTO>();

            foreach (var item in _getSection.AsEnumerable())
            {
                if(item.Value is not null)
                {
                    _languages.Add(new LLDTO
                    {

                        Culture = item.Key.Replace(_targetSection + ":", ""),
                        Name = item.Value


                    });

                }
                
                

            }
            return _languages;
        }

    }
}
