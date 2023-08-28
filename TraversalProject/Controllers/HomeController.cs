using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TraversalProject.Models;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // logger sayesinde örneğin /Home/Index sayfası çağırıldığında output kısmında aşağıdaki bilgi yer alacak
            _logger.LogInformation("Index sayfası çağrıldı");
            _logger.LogError("Error log çağrıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToLongDateString()); 
            _logger.LogInformation(date+"Privacy sayfası çağrıldı.");  // doutput ekranında ate bilgisiyle birlikte mesaj gelecek
            return View();
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfası çağrıldı.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
