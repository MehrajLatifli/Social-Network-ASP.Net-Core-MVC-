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
    public class NotificationSenderManager : INotificationSenderService
    {
        private INotificationSenderDAL _notificationSenderDAL;

        public NotificationSenderManager(INotificationSenderDAL notificationSenderDAL)
        {
            _notificationSenderDAL = notificationSenderDAL;
        }

        public void Add(NotificationSender item)
        {
            _notificationSenderDAL.Add(item);
        }

        public void Delete(NotificationSender item)
        {
            _notificationSenderDAL.Delete(item);
        }

        public List<NotificationSender> GetAll()
        {
            return _notificationSenderDAL.GetList();
        }

        public NotificationSender GetById(int Id)
        {
            return _notificationSenderDAL.Get(p => p.Id == Id);
        }

        public List<NotificationSender> GetByUser(int userId)
        {
            return _notificationSenderDAL.GetList(p => p.UserIdForNotificationLineAsSender == userId || userId == 0);
        }

        public void Update(NotificationSender item)
        {
            _notificationSenderDAL.Update(item);    
        }
    }
}
