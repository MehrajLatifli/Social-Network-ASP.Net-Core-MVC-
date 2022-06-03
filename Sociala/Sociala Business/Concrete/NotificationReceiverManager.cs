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
    public class NotificationReceiverManager : INotificationReceiverService
    {
        private INotificationReceiverDAL _notificationReceiverDAL;

        public NotificationReceiverManager(INotificationReceiverDAL notificationReceiverDAL)
        {
            _notificationReceiverDAL = notificationReceiverDAL;
        }

        public void Add(NotificationReceiver item)
        {
            _notificationReceiverDAL.Add(item);
        }

        public void Delete(NotificationReceiver item)
        {
            _notificationReceiverDAL.Delete(item);
        }

        public List<NotificationReceiver> GetAll()
        {
            return _notificationReceiverDAL.GetList();
        }

        public NotificationReceiver GetById(int Id)
        {
            return _notificationReceiverDAL.Get(p => p.Id == Id);
        }

        public List<NotificationReceiver> GetByUser(int userId)
        {
            return _notificationReceiverDAL.GetList(p => p.UserIdForNotificationLineAsReceiver == userId || userId == 0);
        }

        public void Update(NotificationReceiver item)
        {
            _notificationReceiverDAL.Update(item);
        }
    }
}
