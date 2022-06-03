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
    public class MessageManager : IMessageService
    {
        private IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void Add(Message item)
        {
            _messageDAL.Add(item);
        }

        public void Delete(Message item)
        {
            _messageDAL.Delete(item);
        }

        public List<Message> GetAll()
        {
            return _messageDAL.GetList();
        }

        public Message GetById(int Id)
        {
            return _messageDAL.Get(p => p.Id == Id);
        }

        public List<Message> GetByReceiverUser(int userId)
        {
            return _messageDAL.GetList(p => p.ReceiverUserId == userId || userId == 0);
        }

        public List<Message> GetBySenderUser(int userId)
        {
            return _messageDAL.GetList(p => p.ReceiverUserId == userId || userId == 0);
        }

        public void Update(Message item)
        {
            _messageDAL.Update(item);
        }
    }
}
