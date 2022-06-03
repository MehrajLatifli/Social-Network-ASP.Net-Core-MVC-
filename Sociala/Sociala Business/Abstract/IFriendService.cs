using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface IFriendService
    {
        List<Friend> GetAll();
        List<Friend> GetByUser(int userId);

        void Add(Friend item);
        void Update(Friend item);
        void Delete(Friend item);
        Friend GetById(int Id);
    }
}
