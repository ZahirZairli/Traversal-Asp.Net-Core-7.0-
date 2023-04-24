using BusinessLayer.Abstract;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminExcelController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IExcelService _excelService;
        private readonly IAppUserService _appUserService;

        public AdminExcelController(IDestinationService destinationService, IExcelService excelService, IAppUserService appUserService)
        {
            _destinationService = destinationService;
            _excelService = excelService;
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AppUser()
        {
            return File(_excelService.ExcelList(_appUserService.TGetList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelUser.xlsx");
        }
        public IActionResult DestinationExcel()
        {
            return File(_excelService.ExcelList(_destinationService.TGetList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelTur.xlsx");
        }
    }
}
