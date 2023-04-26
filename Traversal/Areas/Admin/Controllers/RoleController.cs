using DocumentFormat.OpenXml.Office.CustomUI;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;
using X.PagedList;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            if (roles.Count>0)
            {
                TempData["NoRole"] = "alert alert-error alert-dismissible fade show mt-2";
            }
            return View(roles);
        }
        [HttpGet]
        public IActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewRole(AppRole newRole)
        {
            var result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
            TempData["SuccessRole"] = "alert alert-success alert-dismissible fade show mt-2";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }    
                return View(newRole);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
           var result =  await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
             TempData["DeleteSuccessRole"] = "true";
            }
            else
            {
                TempData["DeleteErrorRole"] = "true";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var oldRole = await _roleManager.FindByIdAsync(id.ToString());
            EditedRole editedRole = new EditedRole
            {
                Id = oldRole.Id,
                Name = oldRole.Name
            };
            return View(editedRole);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditedRole editedRole)
        {
            var oldRole = await _roleManager.FindByIdAsync(editedRole.Id.ToString());
            oldRole.Name = editedRole.Name;
            var result = await _roleManager.UpdateAsync(oldRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(editedRole);
            }
        }
        public IActionResult UserList(int page = 1)
        {
            var users = _userManager.Users.ToPagedList(page,10);
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            ViewBag.username = user.UserName;
            TempData["userId"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<UserRolesEdit> userHasRoles = new List<UserRolesEdit>();

            foreach (var item in roles)
            {
                UserRolesEdit role = new UserRolesEdit();
                role.RoleId = item.Id;
                role.RoleName = item.Name;
                role.RoleExist = userRoles.Contains(item.Name);
                userHasRoles.Add(role);
            }

            return View(userHasRoles);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<UserRolesEdit> model)
        {
            var userId = TempData["userId"].ToString();
            var user = _userManager.Users.FirstOrDefault(x => x.Id.ToString() == userId);

            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
