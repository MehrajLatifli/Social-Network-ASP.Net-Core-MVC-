using Sociala_Business.Abstract;
using Sociala_DataAccesss.Abstract;
using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Concrete
{
    public class NotificationManage : INotificationService
    {
        private INotificationDAL  _notificationDAL;

        public NotificationManage(INotificationDAL notificationDAL)
        {
            _notificationDAL = notificationDAL;
        }

        public void Add(Notification item)
        {
            _notificationDAL.Add(item);
        }

        public void Delete(Notification item)
        {
            _notificationDAL.Delete(item);
        }

        public List<Notification> GetAll()
        {
            return _notificationDAL.GetList();
        }

        public Notification GetById(int Id)
        {
            return _notificationDAL.Get(i => i.Id == Id);
        }

        public List<Notification> GetByNotificationReceiver(int NotificationReceiverId)
        {
            return _notificationDAL.GetList(p => p.NotificationReceiverIdForNotification == NotificationReceiverId || NotificationReceiverId == 0);
        }

        public List<Notification> GetByNotificationSender(int NotificationSenderId)
        {
            return _notificationDAL.GetList(p => p.NotificationSenderIdForNotification == NotificationSenderId || NotificationSenderId == 0);
        }

        public void Update(Notification item)
        {
            _notificationDAL.Update(item);
        }
    }
}
