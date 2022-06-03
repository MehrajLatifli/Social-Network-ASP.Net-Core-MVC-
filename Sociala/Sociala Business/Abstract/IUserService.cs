using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();

        void Add(User item);
        void Update(User item);
        void Delete(User item);
        User GetById(int Id);
    }
}
