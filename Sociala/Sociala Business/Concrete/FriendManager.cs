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
    public class FriendManager : IFriendService
    {
        private IFriendDAL _friendDAL;

        public FriendManager(IFriendDAL friendDAL)
        {
            _friendDAL = friendDAL;
        }

        public void Add(Friend item)
        {
            _friendDAL.Add(item);
        }

        public void Delete(Friend item)
        {
            _friendDAL.Delete(item);
        }

        public List<Friend> GetAll()
        {
            return _friendDAL.GetList();
        }

        public Friend GetById(int Id)
        {
            return _friendDAL.Get(p => p.Id == Id);
        }

        public List<Friend> GetByUser(int userId)
        {
            return _friendDAL.GetList(p => p.UserIdForFriend == userId || userId == 0);
        }

        public void Update(Friend item)
        {
            _friendDAL.Update(item);
        }
    }
}
