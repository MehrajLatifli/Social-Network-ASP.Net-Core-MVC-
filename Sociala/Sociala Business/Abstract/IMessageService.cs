using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        List<Message> GetBySenderUser(int userId);
        List<Message> GetByReceiverUser(int userId);

        void Add(Message item);
        void Update(Message item);
        void Delete(Message item);
        Message GetById(int Id);
    }
}
