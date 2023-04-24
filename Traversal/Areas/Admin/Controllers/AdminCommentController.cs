using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        private readonly ICommentService _commentService;

        public AdminCommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetCommentsWithDestinationAndAppUser();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var val = _commentService.TGetById(id);
            _commentService.TDelete(val);
            return RedirectToAction("Index");
        }
    }
}
