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
    public class UserManager : IUserService
    {
        private IUserDAL _usernDAL;

        public UserManager(IUserDAL usernDAL)
        {
            _usernDAL = usernDAL;
        }

        public void Add(User item)
        {
            _usernDAL.Add(item);
        }

        public void Delete(User item)
        {
            _usernDAL.Delete(item);
        }

        public List<User> GetAll()
        {
            return _usernDAL.GetList();
        }

        public User GetById(int Id)
        {
            return _usernDAL.Get(p => p.Id == Id);
        }

        public void Update(User item)
        {
            _usernDAL.Update(item);
        }
    }
}
