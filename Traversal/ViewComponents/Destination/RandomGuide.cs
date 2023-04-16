using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Destination
{
    public class RandomGuide:ViewComponent
    {
        GuideManager gm = new GuideManager(new EfGuideDal());
        private static readonly Random _random = new Random();
        public IViewComponentResult Invoke()
        {
            var guides = gm.TGetList();
            int randomIndex = _random.Next(guides.Count);
            return View(guides[randomIndex]);
        }
    }
}
