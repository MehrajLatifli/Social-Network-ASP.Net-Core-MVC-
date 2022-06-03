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
    public class PostandTagManager : IPostandTagService
    {
        private IPostandTagDAL _postandTagDAL;

        public PostandTagManager(IPostandTagDAL postandTagDAL)
        {
            _postandTagDAL = postandTagDAL;
        }

        public void Add(PostandTag item)
        {
            _postandTagDAL.Add(item);
        }

        public void Delete(PostandTag item)
        {
            _postandTagDAL.Delete(item);
        }

        public List<PostandTag> GetAll()
        {
            return _postandTagDAL.GetList();
        }

        public PostandTag GetById(int Id)
        {
            return _postandTagDAL.Get(p => p.Id == Id);
        }

        public List<PostandTag> GetByPost(int postId)
        {
            return _postandTagDAL.GetList(p => p.PostIdForPostandTag == postId || postId == 0);
        }

        public List<PostandTag> GetByTag(int tagId)
        {
            return _postandTagDAL.GetList(p => p.TagIdForPostandTag == tagId || tagId == 0);
        }

        public void Update(PostandTag item)
        {
            _postandTagDAL.Update(item);
        }
    }
}
