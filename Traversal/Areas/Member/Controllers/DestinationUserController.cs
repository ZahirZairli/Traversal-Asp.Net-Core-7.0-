using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Admin,Member")]
    public class DestinationUserController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IActionResult Index(int page=1)
        {
            var values = dm.TGetListFilter(x => x.Status == true).OrderByDescending(x => x.DestinationId).ToPagedList(page, 10);
            return View(values);
        }
    }
}
