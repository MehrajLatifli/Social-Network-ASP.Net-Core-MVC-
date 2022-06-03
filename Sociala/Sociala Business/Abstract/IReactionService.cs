using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface IReactionService
    {
        List<Reaction> GetAll();
        List<Reaction> GetByPost(int postId);

        void Add(Reaction item);
        void Update(Reaction item);
        void Delete(Reaction item);
        Reaction GetById(int Id);
    }
}
