using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PresentationLayer.Areas.Member.ViewComponents.DashBoardView
{
    public class UserAbout : ViewComponent
    {
        AppUserManager aum = new AppUserManager(new EfAppUserDal());
        public IViewComponentResult Invoke()
        {
            var user = aum.TGetByName(User.Identity.Name);
            return View(user);
        }
    }
}
