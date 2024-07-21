using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HW_7_MusicPortal.Models
{
    public class ViewModelLoggin
    {
        [Required]
        [Remote(action: "CheckLogin", controller: "Loggin", ErrorMessage = "Ваш аккаунт не подтвкрждён...")]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set;}
    }
}

//to-do loggoutUser after block