using System.ComponentModel.DataAnnotations;

namespace CbsTodoList.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Passwords don't match")]
        public string ConfirmPassword { get;set; }
    }
}
