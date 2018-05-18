using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Detaliz2.Code.MTS.XML;
using Detaliz2.Models;

namespace Detaliz2.Controllers
{
    public class SelectDataController : Controller
    {
        //
        // GET: /SelectData/
        DraftToClear clearListClass = new DraftToClear();
        public List<SpecificationList> testSelectDate = new List<SpecificationList>();
        [HttpGet]
        public ActionResult SelectPanel()
        {
            return PartialView();
        }
    }
}