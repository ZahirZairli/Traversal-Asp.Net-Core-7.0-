using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment([FromForm] Comment c)
        {
            c.AppUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            cm.TAdd(c);
            return RedirectToAction("Detail","Destination", new { id = c.DestinationId});
        }
    }
}
