using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Admin,Member")]

    public class CommentUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
