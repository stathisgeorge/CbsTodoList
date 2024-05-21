using System.ComponentModel.DataAnnotations;

namespace CbsTodoList.ViewModels
{
    public class RegisterVM
    {
        
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password should be 8 characters at least")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[^\w]).{8,}$", ErrorMessage = "Password should contain at least one letter and one digit and the length should be at least 8 characters")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Passwords don't match")]
        public string ConfirmPassword { get;set; }
    }
}
