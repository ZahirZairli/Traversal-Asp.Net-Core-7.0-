using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Destination
{
    public class Comments : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var comments = cm.GetCommentsByDestinationId(id).Where(x=>x.Status==true).ToList();
            return View(comments);
        }
    }
}
