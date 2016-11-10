using BeerScheduler.Utilities;
using BeerScheduler.Web.Controllers;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeerScheduler.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            Logger.Log($"{nameof(HomeController)}.{nameof(Index)}", TraceEventType.Information);
            
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