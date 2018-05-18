using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Detaliz2.Code.MTS.XML;
using Detaliz2.Models;
using System.Web.Helpers;
using Detaliz2.Code.Other;

namespace Detaliz2.Controllers
{
    public class TableSpecificationController : Controller
    {
        //
        // GET: /Specification/
        SelectDataInList dataInList = new SelectDataInList();
        public List<SpecificationList> resultSelectInList = new List<SpecificationList>();
        DraftToClear clearListClass = new DraftToClear();
        public List<SpecificationList> resultSelect = new List<SpecificationList>();
       [HttpGet]
        public ActionResult List()
        {
            clearListClass.TransformListInClearList();
            resultSelect = clearListClass.clearList.Select(n => n).ToList();
            return PartialView(resultSelect);
        }

       [HttpPost]
       public ActionResult List(string Service, DateTime DateFirst, DateTime DateLast, string Type)
       {
            foreach (var select in dataInList.ParseSelectInList(Service, Type,
                DateFirst, DateLast))
            {
                resultSelectInList.Add(new SpecificationList
                {
                    Service = select.Service,
                    Type = select.Type,
                    Date = select.Date,
                    Operator = select.Operator,
                    Number = select.Number,
                    Time = select.Time,
                    Duration = select.Duration
                });
            }
            return PartialView(resultSelectInList);
       }


    }
}
