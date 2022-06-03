using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface ITagService
    {
        List<Tag> GetAll();


        void Add(Tag item);
        void Update(Tag item);
        void Delete(Tag item);
        Tag GetById(int Id);
    }
}
