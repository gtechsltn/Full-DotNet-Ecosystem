using ClassLibraryNS20;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationASPNETCoreMVC.Models;

namespace WebApplicationASPNETCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IDBHelper dBHelper = new DBHelper();

            //Using Simple Transaction
            dBHelper.InsertCustomer1();

            //Using Transaction Scope
            dBHelper.InsertCustomer2();

            //Using Dapper Transaction
            dBHelper.InsertCustomer3();

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
