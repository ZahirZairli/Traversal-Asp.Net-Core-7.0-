using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminAnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AdminAnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.TGetList());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(AddAnnouncementDto p)
        {

            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Title = p.Title,
                    Content = p.Content
                });
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }
        public IActionResult Delete(int id)
        {
            var an = _announcementService.TGetById(id);
            _announcementService.TDelete(an);
            TempData["delete"] = "true";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var announcement = _mapper.Map<AnnouncementUpdateDto>(_announcementService.TGetById(id));
            return View(announcement);
        }
        [HttpPost]
        public IActionResult Update(AnnouncementUpdateDto p)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    Title = p.Title,
                    Content = p.Content,
                    AnnouncementId = p.AnnouncementId
                });
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }
    }
}
