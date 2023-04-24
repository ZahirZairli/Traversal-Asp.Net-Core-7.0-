using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Admin,Member")]
    public class ReservationUserController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        ReservatioManager rm = new ReservatioManager(new EfReservationDal());
        AppUserManager apm = new AppUserManager(new EfAppUserDal());
        public IActionResult MyReservationActive()
        {
            var res = rm.TGetReservationsByUserActive(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View(res);
        }
        public IActionResult MyReservationPassive()
        {
            var res = rm.TGetReservationsByUserPassive(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View(res);
        }
        public IActionResult MyReservationApproval()
        {
            TempData["addres"] = TempData["addres"];
            var res = rm.TGetReservationsByUserApproval(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View(res);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            GetDestinations();
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            p.Status = "Rezervasiya təsdiq gözləyir";
            rm.TAdd(p);
            TempData["addres"] = "true";
            return RedirectToAction("MyReservationApproval", "ReservationUser", new { area = "Member"});
        }

        public IActionResult DeleteReservation(int id)
        {
            var des = rm.TGetById(id);
            rm.TDelete(des);
            return RedirectToAction("MyReservationApproval", "ReservationUser", new { area = "Member" });
        }
        public void GetDestinations()
        {
            List<SelectListItem> destinations = (from x in dm.TGetListFilter(x => x.Status == true)
                                                 select new SelectListItem
                                                 {
                                                     Text = x.City,   //optionun metni
                                                     Value = x.DestinationId.ToString()//optionun valuesi
                                                 }).ToList();
            ViewBag.destination = destinations;
        }
    }
}
