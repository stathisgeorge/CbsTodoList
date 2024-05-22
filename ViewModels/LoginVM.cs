
using System.ComponentModel.DataAnnotations;

namespace CbsTodoList.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Return the username from email 
        /// </summary>
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
