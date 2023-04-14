using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Member.ViewComponents.DashBoardView
{
    public class UserInformation : ViewComponent
    {
        AppUserManager aum = new AppUserManager(new EfAppUserDal());
        public IViewComponentResult Invoke()
        {
            var user = aum.TGetByName(User.Identity.Name);
            return View(user);
        }
    }
}
