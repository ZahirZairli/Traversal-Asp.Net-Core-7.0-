using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.CQRS.Commands.DestinationCommands;
using PresentationLayer.CQRS.Handlers.DestinationHandlers;
using PresentationLayer.CQRS.Queries.DestinationQueries;
using X.PagedList;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminDestinationCQRSController : Controller
    {
        private readonly GetDestinationsForStrangersQueryHandler _getDestinationsForStrangersQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public AdminDestinationCQRSController(GetDestinationsForStrangersQueryHandler getDestinationsForStrangersQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getDestinationsForStrangersQueryHandler = getDestinationsForStrangersQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public IActionResult Index(int page = 1,string Destination="")
        {
           var values = _getDestinationsForStrangersQueryHandler.Handle();
            if (Destination !="")
            {
                return View(values.Where(x=>x.City.ToUpper().Contains(Destination.ToUpper())).ToPagedList(page, 5));
            }
            return View(values.ToPagedList(page, 5));
        }
        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var value = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveDestination(int id)
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}
