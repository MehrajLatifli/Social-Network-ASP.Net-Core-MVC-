using Sociala__Web_UI_.Entities;

namespace Sociala__Web_UI_.Helpers
{

    public static class UserHelper
    {
        public static CustomIdentityUser CurrentUser { get; set; }
        public static CustomIdentityUser ReceiverUser { get; set; }
        public static List<CustomIdentityUser> ActiveUsers { get; set; } = new List<CustomIdentityUser>();

    }
}
