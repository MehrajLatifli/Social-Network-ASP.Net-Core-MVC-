using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sociala__Web_UI_.Entities
{
    public class CustomIdentityUser : IdentityUser
    {
        public CustomIdentityUser()
        {
       
        }


        public string ProfilePicture { get; set; }
        [NotMapped]
        public bool IsOnline { get; set; }

    }
}
