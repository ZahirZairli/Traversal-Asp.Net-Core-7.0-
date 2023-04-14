using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    public class CommentUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
