using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface IPostService
    {
        List<Post> GetAll();
        List<Post> GetByUser(int userId);

        void Add(Post item);
        void Update(Post item);
        void Delete(Post item);
        Post GetById(int Id);
    }
}
