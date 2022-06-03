using Sociala_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociala_Business.Abstract
{
    public interface IPostandTagService
    {
        List<PostandTag> GetAll();

        List<PostandTag> GetByTag(int tagId);
        List<PostandTag> GetByPost(int postId);

        void Add(PostandTag item);
        void Update(PostandTag item);
        void Delete(PostandTag item);
        PostandTag GetById(int Id);
    }
}
