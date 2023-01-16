using Microsoft.AspNetCore.Mvc;
using Reminder.FE.Models;
using System.Diagnostics;

namespace Reminder.FE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SimpleAES simpleAES = new SimpleAES();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string userName = simpleAES.DecryptString(HttpContext.Session.GetString("EncryptedUserName"));
            string  Email = simpleAES.DecryptString(HttpContext.Session.GetString("EncryptedEmail"));
            HttpContext.Session.SetString("UserName", userName);
            HttpContext.Session.SetString("Email", Email);

            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}