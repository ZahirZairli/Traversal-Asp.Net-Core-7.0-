using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Member.ViewComponents.DashBoardView
{
    public class DashboardGuide : ViewComponent
    {
        GuideManager gm = new GuideManager(new EfGuideDal());

        public IViewComponentResult Invoke()
        {
            var values = gm.TGetListFilter(x => x.Status == true);
            return View(values);
        }
    }
}
