using BusinessLayer.Abstract.AbstractUnitOfWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AccountUnitOfWorkController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountUnitOfWorkController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountUnitOfWork model)
        {
            var sender = _accountService.TGetById(model.SenderId);
            var receiver = _accountService.TGetById(model.ReceiverId);

            if (sender != null && receiver != null && model.Amount > 0)
            {
                if (sender.Balance >= model.Amount)
                {
                    sender.Balance -= model.Amount;
                    receiver.Balance += model.Amount;

                    List<Account> modifiedAccounts = new List<Account>()
                {
                    sender,
                    receiver
                };
                    _accountService.TMultiUpdate(modifiedAccounts);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.balance = sender.Balance;
                    TempData["error"] = "true";
                }
            }
            TempData["accountnull"] = "null";
            return View(model);
        }
    }
}
