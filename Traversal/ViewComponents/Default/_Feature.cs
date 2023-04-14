using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var features = fm.TGetListFilter(x => x.Status == true && x.MainStatus == false).OrderByDescending(x=>x.FeatureId).Take(4).ToList();
            var figure = fm.TGetListFilter(x=>x.Status == true && x.MainStatus == true).OrderByDescending(x=>x.FeatureId).FirstOrDefault();
            ViewBag.image = figure.Image;
            ViewBag.title = figure.Title;
            ViewBag.des = figure.Description;
            return View(features);
        }
    }
}
