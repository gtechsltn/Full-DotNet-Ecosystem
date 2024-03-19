using ClassLibraryNS20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationASPNETMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}