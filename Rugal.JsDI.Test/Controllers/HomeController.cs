using Microsoft.AspNetCore.Mvc;
using Rugal.JavaScriptDataInject.Attributes;
using Rugal.JavaScriptDataInject.Test.Models;
using System.Diagnostics;

namespace Rugal.JavaScriptDataInject.Test.Controllers
{
    [JsDI]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index(string Name, string Value)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
