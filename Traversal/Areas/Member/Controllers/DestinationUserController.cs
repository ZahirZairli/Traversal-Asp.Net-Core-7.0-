using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    public class DestinationUserController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = dm.TGetListFilter(x=>x.Status==true).OrderByDescending(x=>x.DestinationId).ToList();
            return View(values);
        }
    }
}
