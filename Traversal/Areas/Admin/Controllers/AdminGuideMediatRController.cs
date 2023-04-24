using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.CQRS.Commands.GuideCommands;
using PresentationLayer.CQRS.Handlers.GuideHandlers;
using PresentationLayer.CQRS.Queries.GuideQueries;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminGuideMediatRController : Controller
    {
        private readonly IMediator _mediatR;

        public AdminGuideMediatRController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediatR.Send(new GetAllGuideQuery());
            return View(values);
        }
        public async Task<IActionResult> GetGuideById(int id)
        {
            var value = await _mediatR.Send(new GetGuideByIdQuery(id));
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGuide(CreateGuideCommand command)
        {
            await _mediatR.Send(command);
            return RedirectToAction("Index");
        }
    }
}
