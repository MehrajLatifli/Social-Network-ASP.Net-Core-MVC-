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
    public class CommentManager : ICommentService
    {

        private ICommentDAL _commentDAL;

        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        public void Add(Comment item)
        {
            _commentDAL.Add(item);
        }

        public void Delete(Comment item)
        {
            _commentDAL.Delete(item);
        }

        public List<Comment> GetAll()
        {
            return _commentDAL.GetList();
        }

        public Comment GetById(int Id)
        {
            return _commentDAL.Get(p => p.Id == Id);
        }

        public List<Comment> GetByPost(int postId)
        {
            return _commentDAL.GetList(p => p.PostIdForComment == postId || postId == 0);
        }

        public List<Comment> GetByUser(int userId)
        {
            return _commentDAL.GetList(p => p.UserIdForComment == userId || userId == 0);
        }

        public void Update(Comment item)
        {
            _commentDAL.Update(item);
        }
    }
}
