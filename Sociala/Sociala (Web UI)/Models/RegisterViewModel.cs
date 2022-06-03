using Sociala__Web_UI_.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sociala__Web_UI_.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
       [DisplayName("Upload image")]
        [FileSize(5555555, 555555)] // min: 0.5298185348510742 MB; max: 5.298190116882324 MB
        [AllowedExtensions(new string[] {".png" })]
        public IFormFile FilePath { get; set; }

        public string ImageUrl { get; set; } = "images/person.png";
    }
}
