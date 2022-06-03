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
    public class TagManager : ITagService
    {
        private ITagDAL _tagDAL;

        public TagManager(ITagDAL tagDAL)
        {
            _tagDAL = tagDAL;
        }

        public void Add(Tag item)
        {
            _tagDAL.Add(item);
        }

        public void Delete(Tag item)
        {
            _tagDAL.Delete(item);
        }

        public List<Tag> GetAll()
        {
            return _tagDAL.GetList();
        }

        public Tag GetById(int Id)
        {
            return _tagDAL.Get(p => p.Id == Id);
        }




        public void Update(Tag item)
        {
            _tagDAL.Update(item);
        }
    }
}
