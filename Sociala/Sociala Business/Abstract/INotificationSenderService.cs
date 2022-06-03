using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface INotificationSenderService
    {
        List<NotificationSender> GetAll();
        List<NotificationSender> GetByUser(int userId);

        void Add(NotificationSender item);
        void Update(NotificationSender item);
        void Delete(NotificationSender item);
        NotificationSender GetById(int Id);
    }
}
