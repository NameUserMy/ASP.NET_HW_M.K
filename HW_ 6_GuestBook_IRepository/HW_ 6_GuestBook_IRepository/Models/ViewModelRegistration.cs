using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HW__6_GuestBook_IRepository.Models
{
    public class ViewModelRegistration
    {
        [Required]
        [RegularExpression(@"[a-z,A-Z]{3,}\d{2,}\w{5,15}", ErrorMessage = "(min 3 letters 2 num, min 10  max 20 s)")]
        [Remote(action: "CheckLogin", controller: "Registration", ErrorMessage = "Login уже используется")]
        public string? Login {  get; set; }

        [Required]
        [RegularExpression(@"[a-z,A-Z]{3,}\d{2,}\w{5,15}", ErrorMessage = "(min 3 letters 2 num, min 10  max 20 s)")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
     
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"[a-z,A-Z]{3,10}", ErrorMessage = "(min 3  max 10 letters)")]
        [Remote(action: "CheckNickName", controller: "Registration", ErrorMessage = "NickName уже используется")]
        public string? NickName {  get; set; }
        //Use01ddddd parol
    }
}
