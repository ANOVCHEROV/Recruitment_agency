using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecAgency.Models;
using Microsoft.AspNet.Identity;

namespace RecAgency.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Log.For(this).Info("User " + User.Identity.GetUserId() + " arrived to start page");
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
        public ActionResult Error(string error)
        {
            var er = new Error();
            er.textError = error;
            return View(er);
        }
    }
}