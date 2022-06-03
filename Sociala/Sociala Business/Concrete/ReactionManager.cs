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

    public class ReactionManager : IReactionService
    {
        private IReactionDAL _reactionDAL;

        public ReactionManager(IReactionDAL reactionDAL)
        {
            _reactionDAL = reactionDAL;
        }

        public void Add(Reaction item)
        {
            _reactionDAL.Add(item);
        }

        public void Delete(Reaction item)
        {
            _reactionDAL.Delete(item);
        }

        public List<Reaction> GetAll()
        {
            return _reactionDAL.GetList();
        }

        public Reaction GetById(int Id)
        {
            return _reactionDAL.Get(p => p.Id == Id);
        }

        public List<Reaction> GetByPost(int postId)
        {
            return _reactionDAL.GetList(p => p.PostIdForReaction == postId || postId == 0);
        }

        public void Update(Reaction item)
        {
            _reactionDAL.Update(item);
        }
    }

}
