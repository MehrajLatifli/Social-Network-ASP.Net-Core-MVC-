using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sociala__Web_UI_.Entities
{
    public class CustomIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {

        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options) : base(options)
        {

        }
    }
}
