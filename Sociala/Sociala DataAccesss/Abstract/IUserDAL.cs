using Sociala_Core.DataAccess;
using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_DataAccesss.Abstract
{
    public interface IUserDAL : IEntityRepository<User>
    {
    }
}
