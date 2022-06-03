using Sociala_Entities.Concrete.DatabaseFirst;

namespace Sociala__Web_UI_.Services
{
    public interface INotificationSessionService
    {
        Notification GetCart();

        void SetCart(Notification notification);
    }
}
