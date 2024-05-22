using System.ComponentModel.DataAnnotations;

namespace CbsTodoList.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password should be 8 characters at least")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Passwords don't match")]
        public string ConfirmPassword { get;set; }

        public string? Username
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Email))
                    return Email.Substring(0, Email.IndexOf("@"));
                else
                    return null;
            }
        }
    }
}
