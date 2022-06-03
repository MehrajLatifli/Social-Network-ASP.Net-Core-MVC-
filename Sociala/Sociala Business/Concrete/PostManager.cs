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
    public class PostManager : IPostService
    {
        private IPostDAL _postDAL;

        public PostManager(IPostDAL postDAL)
        {
            _postDAL = postDAL;
        }

        public void Add(Post item)
        {
            _postDAL.Add(item);
        }

        public void Delete(Post item)
        {
            _postDAL.Delete(item);
        }

        public List<Post> GetAll()
        {
            return _postDAL.GetList();
        }

        public Post GetById(int Id)
        {
            return _postDAL.Get(p => p.Id == Id);
        }

        public List<Post> GetByUser(int userId)
        {
            return _postDAL.GetList(p => p.UserIdForPost == userId || userId == 0);
        }

        public void Update(Post item)
        {
            _postDAL.Update(item);
        }
    }
}
