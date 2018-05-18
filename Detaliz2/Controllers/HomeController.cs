using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Detaliz2.Models;
using Detaliz2.Code.MTS.XML;

namespace Detaliz2.Controllers
{
    public class HomeController : Controller
    {
        DraftToClear clearListClass = new DraftToClear();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Collapse(string Service, string Type, DateTime DateFirst, DateTime DateLast)
        {
            ViewBag.DateFirst = DateFirst;
            ViewBag.DateLast = DateLast;
            ViewBag.Service = Service;
            ViewBag.Type = Type;
            return PartialView();
        }
    }
}