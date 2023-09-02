using BusinessLayer.Abstract.AbstractUow;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TraversalProject.Areas.Admin.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(AccountViewModel model)
        {
            var sender = _accountService.TGetByID(model.SenderID);
            var receiver = _accountService.TGetByID(model.ReceiverID);

            sender.Balance -= model.Amount;  // gönderen kişinin bakiyesinden gönderilen para miktarını çıkar
            receiver.Balance += model.Amount; // alıcının bakiyesine gönderilen miktarı ekle

            List<Account> modifiedAccounts = new List<Account>()
            {
                sender,
                receiver   // modifiedAccounts objesinin içerisinde List biçimde sender ve receiver bilgisi tutulacak.
            };

            _accountService.TMultiUpdate(modifiedAccounts);

            return View();
        }
    }
}
