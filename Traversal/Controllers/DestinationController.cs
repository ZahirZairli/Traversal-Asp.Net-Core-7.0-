using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var des = dm.TGetListFilter(x => x.Status == true);
            return View(des);
        }
        public IActionResult Detail(int id)
        {
            var des = dm.TGetById(id);
            return View(des);
        }
    }
}
