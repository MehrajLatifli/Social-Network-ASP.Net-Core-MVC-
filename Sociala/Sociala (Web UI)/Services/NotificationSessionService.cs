using Sociala_Entities.Concrete.DatabaseFirst;
using Microsoft.AspNetCore.Http;
using Sociala__Web_UI_.ExtentionMethods;

namespace Sociala__Web_UI_.Services
{
    public class NotificationSessionService : INotificationSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public NotificationSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Notification GetCart()
        {
            var notification = _httpContextAccessor.HttpContext.Session.GetObject<Notification>("notification");

            if (notification == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("notification", new Notification());

                notification = _httpContextAccessor.HttpContext.Session.GetObject<Notification>("notification");
            }

            return notification;
        }

        public void SetCart(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
