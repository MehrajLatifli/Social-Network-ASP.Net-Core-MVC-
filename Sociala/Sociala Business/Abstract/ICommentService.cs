using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        List<Comment> GetByUser(int userId);
        List<Comment> GetByPost(int postId);

        void Add(Comment item);
        void Update(Comment item);
        void Delete(Comment item);
        Comment GetById(int Id);
    }
}
