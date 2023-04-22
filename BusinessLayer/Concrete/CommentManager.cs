using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> GetCommentsByDestinationId(int id)
        {
            return _commentDal.ListCondition(x => x.DestinationId == id);
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentsWithAppUserAndDestination(int destinationId)
        {
            return _commentDal.GetCommentsWithAppUserAndDestination(destinationId);
        }

        public List<Comment> TGetCommentsWithDestination()
        {
            return _commentDal.GetCommentsWithDestination();
        }

        public List<Comment> TGetCommentsWithDestinationAndAppUser()
        {
            return _commentDal.GetCommentsWithDestinationAndAppUser();
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetListAll();
        }

        public List<Comment> TGetListFilter(Expression<Func<Comment, bool>> filter)
        {
            return _commentDal.ListCondition(filter);
        }
        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
