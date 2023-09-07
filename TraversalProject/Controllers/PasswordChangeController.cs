using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using TraversalProject.Models;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new   // Şifremi unuttum kısmına bastığında PasswordChange/ResetPasword sayfasına gidecek
            {
                userId= user.Id,
                token=passwordResetToken
            },HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "uiswagger@gmail.com"); // mail gönderenin bilgileri
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);  // maili alacak olanın bilgileri
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = "Şifre Değişiklik Talebi";  // mailin konusu

            var bodyBuilder = new BodyBuilder();  // mailin içerik kısmı
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); //mailin port numarası 587
            client.Authenticate("uiswagger@gmail.com", "honqartztzzsrdxt"); // mail hesabındaki uygulama şifreleri kısmına girerek aldığımız kod
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string userID, string token)
        {
            TempData["userID"] = userID;
            TempData["token"] = token;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userID = TempData["userID"];
            var token = TempData["token"];
            if(userID==null || token==null)
            {
                // hata mesajı
            }
            var user = await _userManager.FindByIdAsync(userID.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
