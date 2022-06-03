using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Sociala__Web_UI_.Models;

namespace Sociala__Web_UI_.ViewComponnents
{
    public class UserSummaryViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            UserDetailsViewModel model = new UserDetailsViewModel
            {
                Username = HttpContext.User.Identity.Name
            };

            return View(model);
        }
    }
}
