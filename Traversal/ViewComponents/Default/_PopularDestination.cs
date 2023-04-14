using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Default
{
    public class _PopularDestination : ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var destinations = dm.TGetListFilter(x => x.Status == true).OrderByDescending(x => x.DestinationId).ToList();
            return View(destinations);
        }
    }
}
