using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentsWithAppUserAndDestination(int destinationId)
        {
            using (var c = new Context())
            {
                return c.Comments.Where(x=>x.DestinationId==destinationId).Include(x => x.AppUser).ToList();
            }
        }

        public List<Comment> GetCommentsWithDestination()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x=>x.Destination).OrderByDescending(x=>x.CommentId).ToList();
            }
        }

        public List<Comment> GetCommentsWithDestinationAndAppUser()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Destination).Include(x=>x.AppUser).OrderByDescending(x => x.CommentId).ToList();
            }
        }
    }
}
