using Microsoft.AspNetCore.Mvc;
using Resources;
using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models.FormModels
{
    public class ViewModelRegistration
    {

       
        [Required]
        [RegularExpression(@"[a-z,A-Z]{3,}\d{2,}\w{5,15}", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "CheckLogin")]
        [Remote(action: "CheckLogin", controller: "Registration", ErrorMessage = "Login уже используется")]
        public string? Login { get; set; }

        [Required]
        [RegularExpression(@"[a-z,A-Z]{3,}\d{2,}\w{5,15}", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "CheckLogin")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"[a-z,A-Z]{3,10}", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "GenreSimbol")]
        [Remote(action: "CheckNickName", controller: "Registration", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "NickName")]
        public string? NickName { get; set; }

    }
}
