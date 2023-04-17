using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;

namespace PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        AppUserManager am = new AppUserManager(new EfAppUserDal());
        public IActionResult Index(int page = 1)
        {
            var des = dm.TGetListFilter(x => x.Status == true);
            return View(des.ToPagedList(page, 6));
        }
        public IActionResult Detail(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                int AppUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var user = am.TGetById(AppUserId);
                ViewBag.userimage = user.Image;
                ViewBag.name = user.Name + " " + user.Surname;
            }
            var des = dm.TGetByIdWithGuide(id);
            return View(des);
        }
    }
}
