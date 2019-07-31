using System.ComponentModel.DataAnnotations;

namespace MemeRSity.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        public string Country { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}