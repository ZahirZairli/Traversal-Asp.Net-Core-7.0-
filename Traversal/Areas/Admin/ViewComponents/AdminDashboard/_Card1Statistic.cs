using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.ViewComponents.AdminDashboard
{
    public class _Card1Statistic : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.des = c.Destinations.Count();
            ViewBag.user = c.Users.Count();
            return View();
        }
    }
}
