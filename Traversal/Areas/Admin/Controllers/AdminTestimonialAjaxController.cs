using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminTestimonialAjaxController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public AdminTestimonialAjaxController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TestiMonialsList()
        {
            var jsonTestimonial = JsonConvert.SerializeObject(_testimonialService.TGetList());
            return Json(jsonTestimonial);
        }
        public IActionResult TestiMonialsWithName(string data)
        {
            var jsonTestimonial = JsonConvert.SerializeObject(_testimonialService.GetWithName(data));
            return Json(jsonTestimonial);
        }
        [HttpPost]
        public IActionResult TestiMonialsAdd(Testimonial testValues)
        {
            testValues.Image = "user.png";
            _testimonialService.TAdd(testValues);
            var value = JsonConvert.SerializeObject(testValues);
            return Json(value);
        }
        public IActionResult TestiMonialsDelete(int id)
        {
            var test = _testimonialService.TGetById(id);
            _testimonialService.TDelete(test);
            var jsonTestimonial = JsonConvert.SerializeObject(test);
            return Json(jsonTestimonial);
        }
    }
}
