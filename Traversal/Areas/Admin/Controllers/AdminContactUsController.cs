using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public AdminContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.TGetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var message = _contactUsService.TGetById(id);
            _contactUsService.TDelete(message);
            TempData["messagedelete"] = "true";
            return RedirectToAction("Index");
        }
    }
}
