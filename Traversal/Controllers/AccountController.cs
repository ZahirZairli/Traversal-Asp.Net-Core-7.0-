using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NuGet.Protocol;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterViewModel p)
		{
			AppUser user = new AppUser
			{
				Name = p.Name,
				Surname = p.Surname,
				Email = p.Mail,
				UserName = p.UserName,
				Image = "user.png",
				PhoneNumber = p.Phone,
			};

			if (p.Password != null && p.ConfirmPassword != null)
			{
				var result = await _userManager.CreateAsync(user, p.Password);
				if (result.Succeeded)
				{
					var newUserAddRole = _userManager.Users.FirstOrDefault(x=>x.UserName==user.UserName);
					await _userManager.AddToRoleAsync(newUserAddRole, "Member");
					return RedirectToAction("Login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(p);
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserLoginViewModel p)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(p.UserName, p.UserPassword, false, true);
				//1-ci false=> Xatırlamaq
				//2-ci true=> Şifrənin 5 dəfə yanlış olması nəticəsində bloklanması
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "DashBoardUser", new { area = "Member" });
				}
				if (result.IsLockedOut)
				{
					TempData["locked"] = "true";
				}
			}
			return View(p);
		}
		public async Task<IActionResult> LogOut()
		{
            await _signInManager.SignOutAsync();
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            return RedirectToAction("Index", "Default");
		}
		public IActionResult AccessDenied()
		{
			return View();
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
			if (user != null)
			{
				string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

				var passwordResetTokenLink = Url.Action("ResetPassword", "Account", new
				{
					userId = user.Id,
					token = passwordResetToken
				}, HttpContext.Request.Scheme);


				MimeMessage mimeMessage = new MimeMessage();
				MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal", "zahirzairli@gmail.com");
				mimeMessage.From.Add(mailboxAddressFrom);
				MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
				mimeMessage.To.Add(mailboxAddressTo);

				mimeMessage.Subject = "Şifrə yenilənməsi";

				var bodyBuilder = new BodyBuilder();
				bodyBuilder.TextBody = passwordResetTokenLink;
				mimeMessage.Body = bodyBuilder.ToMessageBody();

				SmtpClient client = new SmtpClient();
				client.Connect("smtp.gmail.com", 587, false);
				//zahirtraversal@gmail.com  
				client.Authenticate("zahirzairli@gmail.com", "cpkmbxsuoperzifm");
				var result = client.Send(mimeMessage);
				client.Disconnect(true);
				TempData["SendSuccess"] = "true";
			}
			else
			{
				TempData["SendError"] = "true";
			}
			return View();
		}
		[HttpGet]
		public IActionResult ResetPassword(string userId, string token)
		{
			TempData["userId"] = userId;
			TempData["token"] = token;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
		{
			var userId = "";
			var token = "";

			if (TempData["userId"] != null)
			{
				userId = TempData["userId"].ToString();
				token = TempData["token"].ToString();
				resetPasswordViewModel.token = token;
				resetPasswordViewModel.userId = userId;
			}
			else
			{
				userId = resetPasswordViewModel.userId;
				token = resetPasswordViewModel.token;
			}

			if (ModelState.IsValid)
			{

				if (userId == null || token == null)
				{
					return RedirectToAction("ForgetPassword");
				}
				var user = await _userManager.FindByIdAsync(userId);
				var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordViewModel.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(resetPasswordViewModel);
		}
	}
}
