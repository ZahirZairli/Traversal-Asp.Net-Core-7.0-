using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Member.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public AdminUserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var users = _appUserService.TGetList();
            return View(users);
        }
        public IActionResult Delete(int id)
        {
            var user = _appUserService.TGetById(id);
            _appUserService.TDelete(user);
            TempData["userdelete"] = "true";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _appUserService.TGetById(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser(int id)
        {
            var comments = _appUserService.TGetList();
            return View(comments);
        }
        public IActionResult ReservationUser(int id)
        {
            var res = _reservationService.TGetReservationsByUserPassive(id);
            var user = _appUserService.TGetById(id);
            ViewBag.fullname = user.Name + user.Surname;
            return View(res);
        }

    }
}
