using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface INotificationService
    {

        List<Notification> GetAll();

        List<Notification> GetByNotificationSender(int NotificationSenderId);
        List<Notification> GetByNotificationReceiver(int NotificationReceiverId);

        void Add(Notification item);
        void Update(Notification item);
        void Delete(Notification item);
        Notification GetById(int Id);

    }
}
