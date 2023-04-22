using DocumentFormat.OpenXml.Office.CustomUI;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
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
    }
}
