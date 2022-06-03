using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface INotificationReceiverService
    {
        List<NotificationReceiver> GetAll();
        List<NotificationReceiver> GetByUser(int userId);

        void Add(NotificationReceiver item);
        void Update(NotificationReceiver item);
        void Delete(NotificationReceiver item);
        NotificationReceiver GetById(int Id);
    }
}
