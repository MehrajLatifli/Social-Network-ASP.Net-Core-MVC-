using Sociala__Web_UI_.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sociala__Web_UI_.Models
{
    public class UploadFile
    {
        [Required]
        [DisplayName("Upload video")]
        [FileSize(5555555, 555555)] // min: 0.5298185348510742 MB; max: 5.298190116882324 MB
        [AllowedExtensions(new string[] { ".mp4", ".wmv" })]
        public IFormFile videoPath { get; set; }


        [Required]
        [DisplayName("Upload image")]
        [FileSize(5555555, 555555)] // min: 0.5298185348510742 MB; max: 5.298190116882324 MB
        [AllowedExtensions(new string[] { ".png", ".jpeg" })]
        public IFormFile imagePath { get; set; }
    }
}
