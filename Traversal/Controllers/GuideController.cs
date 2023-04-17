using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index(int page=1)
        {
            var guides = _guideService.TGetListFilter(x => x.Status == true);
            return View(guides.ToPagedList(page,4));
        }
    }
}
