using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Member.Models;
using System.Security.Claims;

namespace PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Admin,Member")]
    public class ProfileUserController : Controller
    {
        AppUserManager aum = new AppUserManager(new EfAppUserDal());
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = aum.TGetById(userid);
            UserEditViewModel us = new UserEditViewModel
            {
                name = user.Name,
                surname = user.Surname,
                password = user.PasswordHash,
                confirmpassword = user.PasswordHash,
                phonenumber = user.PhoneNumber,
                mail = user.Email,
                imageUrl = user.Image
            };
            return View(us);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/Images/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.Image = imagename;
            }
            user.Name = p.name;
            user.Surname = p.surname;
            user.PhoneNumber = p.phonenumber;
            user.Email = p.mail;
            if (p.password != null && p.confirmpassword != null && p.password == p.confirmpassword)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(p);
        }
    }
}
