using Sociala_Core.DataAccess.EntityFrameworkCore;
using Sociala_DataAccesss.Abstract;
using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_DataAccesss.Concrete
{
    public class EF_NotificationSenderDAL : EF_EntityRepositoryBase<NotificationSender, SocialadbContext>, INotificationSenderDAL
    {
    }
}
