using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;
using System.Net.Mail;
using System.Net;

namespace SchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult History()
        {
            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult StudentLaw()
        {
            return View();
        }

        public ActionResult Admission()
        {
            return View();
        }
    }
}