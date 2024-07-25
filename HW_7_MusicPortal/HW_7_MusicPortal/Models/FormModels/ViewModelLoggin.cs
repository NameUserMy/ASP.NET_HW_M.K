using Microsoft.AspNetCore.Mvc;
using Resources;
using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models.FormModels
{
    public class ViewModelLoggin
    {
        [Required (ErrorMessageResourceType = typeof(Resource),
            ErrorMessageResourceName = "RequiredField")]
        [Remote(action: "CheckLogin", controller: "Loggin", ErrorMessageResourceType = typeof(Resource), 
            ErrorMessageResourceName = "AccountNotConfirm")]
        public string? Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource),
           ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}

//to-do loggoutUser after block