using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DashBoardUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
