using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminDestinationController : Controller
    {
        private readonly IDestinationService dm;

        public AdminDestinationController(IDestinationService dm)
        {
            this.dm = dm;
        }

        public IActionResult Index()
        {
            var values = dm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDestination(Destination newdes,IFormFile Image,IFormFile CoverImage,IFormFile Image2)
        {

            if (Image != null)
            {
                var extension = Path.GetExtension(Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                Image.CopyTo(stream);
                newdes.Image = newimagename;
            }
            if (CoverImage != null)
            {
                var extension2 = Path.GetExtension(CoverImage.FileName);
                var newimagename2 = Guid.NewGuid() + extension2;
                var location2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename2);
                var stream2 = new FileStream(location2, FileMode.Create);
                CoverImage.CopyTo(stream2);
                newdes.CoverImage= newimagename2;
            }
            if (Image2 != null)
            {
                var extension3 = Path.GetExtension(Image2.FileName);
                var newimagename3 = Guid.NewGuid() + extension3;
                var location3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newimagename3);
                var stream3 = new FileStream(location3, FileMode.Create);
                CoverImage.CopyTo(stream3);
                newdes.Image2 = newimagename3;
            }


            dm.TAdd(newdes);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var value = dm.TGetById(id);
            dm.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = dm.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Destination ds)
        {
            dm.TUpdate(ds);
            return RedirectToAction("Index");
        }

    }
}
