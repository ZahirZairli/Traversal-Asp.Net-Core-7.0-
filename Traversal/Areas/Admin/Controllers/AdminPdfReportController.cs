using BusinessLayer.Abstract;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminPdfReportController : Controller
    {
        private readonly IDestinationService _destinationService;

        public AdminPdfReportController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DestinationPdf()
        {
            Guid name = new Guid();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + name + ".pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdftable = new PdfPTable(4);
            pdftable.AddCell("Şəhər");
            pdftable.AddCell("Vaxt");
            pdftable.AddCell("Qiymet");
            pdftable.AddCell("Tutum");

            var values = _destinationService.TGetList();
            foreach (var item in values)
            {
                pdftable.AddCell(item.City);
                pdftable.AddCell(item.DayNight);
                pdftable.AddCell(item.Price.ToString());
                pdftable.AddCell(item.Capacity.ToString());
            }
            document.Add(pdftable);
            document.Close();
            return File("/pdfreports/"+name+".pdf","application/pdf",name+".pdf");
        }
    }
}
