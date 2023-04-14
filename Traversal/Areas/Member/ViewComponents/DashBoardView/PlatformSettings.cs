using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Member.ViewComponents.DashBoardView
{
    public class PlatformSettings : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
