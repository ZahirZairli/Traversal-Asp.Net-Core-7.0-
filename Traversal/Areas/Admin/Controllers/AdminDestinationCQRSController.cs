using Microsoft.AspNetCore.Mvc;
using PresentationLayer.CQRS.Handlers.DestinationHandlers;
using PresentationLayer.CQRS.Queries.DestinationQueries;
using X.PagedList;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminDestinationCQRSController : Controller
    {
        private readonly GetDestinationsForStrangersQueryHandler _getDestinationsForStrangersQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;

        public AdminDestinationCQRSController(GetDestinationsForStrangersQueryHandler getDestinationsForStrangersQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler)
        {
            _getDestinationsForStrangersQueryHandler = getDestinationsForStrangersQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
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
        public IActionResult GetDestination(int id)
        {
            var value = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(value);
        }
    }
}
