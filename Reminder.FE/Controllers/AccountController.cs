using Reminder.FE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net;
using System.Net.Http.Headers;
using Reminder.DB.Interfaces;
using Microsoft.Extensions.Configuration;
using Reminder.FE;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Localization;
using Reminder.DB.Models;

namespace Reminder.FE.Controllers
{
    public class AccountController : Controller
    {
        private SimpleAES simpleAES = new SimpleAES();
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel LoginModel)
        {
            try {
                var user = _unitOfWork.UserTbls.Find(a => a.UserName == LoginModel.UserName && a.Password==LoginModel .Password);
                if(user == null)
                {
                    ModelState.AddModelError("UserName","Username or Password incorrect");
                    return View(LoginModel);
                }

                HttpContext.Session.SetString("EncryptedUserID", simpleAES.EncryptToString(user.Id.ToString()));
                HttpContext.Session.SetString("EncryptedUserName", simpleAES.EncryptToString(user.UserName.ToString()));
                HttpContext.Session.SetString("EncryptedEmail", simpleAES.EncryptToString(user.Email.ToString()));
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        public async Task<ActionResult> ExitAsync()
        {
            HttpContext.Session.Remove("EncryptedUserName");
            HttpContext.Session.Remove("EncryptedUserID");
            HttpContext.Session.Remove("EncryptedEmail");
            HttpContext.Session.Clear();
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //you write this when you use FormsAuthentication
            return RedirectToAction("Login", "Account");

        }
      
    }
}
