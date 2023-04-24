using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminGuideController : Controller
    {
        private readonly IGuideService _guideService;
        public AdminGuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var guides = _guideService.TGetList();
            return View(guides);
        }

        [HttpGet]
        public IActionResult NewGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewGuide(NewGuide newGuide)
        {
            if (ModelState.IsValid)
            {
                Guide newgg = new Guide();

                if (newGuide.Image != null)
                {
                    var extension = Path.GetExtension(newGuide.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    newGuide.Image.CopyTo(stream);
                    newgg.Image= newimagename;
                }
                newgg.FullName = newGuide.FullName;
                newgg.InstagramUrl = newGuide.InstagramUrl;
                newgg.TwitterUrl = newGuide.TwitterUrl;
                newgg.Description = newGuide.Description;
                _guideService.TAdd(newgg);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newGuide);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var guide = _guideService.TGetById(id);

            return View(guide);
        }
        [HttpPost]
        public IActionResult Edit(Guide newGuide)
        {
            _guideService.TUpdate(newGuide);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var guide = _guideService.TGetById(id);
            _guideService.TDelete(guide);
            return RedirectToAction("Index");
        }
        public IActionResult MakeActive(int id)
        {
            var guide = _guideService.TGetById(id);
            guide.Status = true;
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
        public IActionResult MakePassive(int id)
        {
            var guide = _guideService.TGetById(id);
            guide.Status = false;
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
    }
}
