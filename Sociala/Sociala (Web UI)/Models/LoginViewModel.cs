using System.ComponentModel.DataAnnotations;

namespace Sociala__Web_UI_.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }

    }
}
