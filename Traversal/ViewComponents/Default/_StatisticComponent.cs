using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
namespace PresentationLayer.ViewComponents.Default
{
    public class _StatisticComponent : ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        GuideManager gm = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            ViewBag.destinationcount = dm.TGetListFilter(x => x.Status == true).Count();
            ViewBag.guidecount = gm.TGetListFilter(x => x.Status == true).Count();
            return View();
        }
    }
} 
