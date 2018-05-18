using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Detaliz2.Models;
using Detaliz2.Code.MTS.XML;
using Detaliz2.Code.Other;

namespace Detaliz2.Controllers
{
    public class OperatorChartController : Controller
    {
        DraftToClear clearListClass = new DraftToClear();
        SelectDataInList dataInList = new SelectDataInList();
        public List<SpecificationList> resultSelectInList = new List<SpecificationList>();
        [HttpGet]
        public PartialViewResult ShowChartCall()
        {
            clearListClass.TransformListInClearList();
            resultSelectInList = clearListClass.clearList.Select(n => n).ToList();
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ShowChartCall(string Service, string Type, DateTime DateFirst, DateTime DateLast)
        {
            foreach(var select in dataInList.ParseSelectInList(Service,Type, 
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
            TotalTime totalTime = new TotalTime(resultSelectInList);
            totalTime.SummarizeDurationPercentOperator();

            ViewBag.DurationCall = new double[5];
            ViewBag.PercentDurationCall = new double[5];
            ViewBag.DurationSms = new double[5];
            ViewBag.PercentDurationSms = new double[5];
            for (int i = 0; i < 5; i++)
            {
                    ViewBag.DurationCall[i] = totalTime.durationEachOperatorCall[i];
                    ViewBag.PercentDurationCall[i] = totalTime.percentDurationEachOperatorCall[i];
                    ViewBag.DurationSms[i] = totalTime.durationEachOperatorSms[i];
                    ViewBag.PercentDurationSms[i] = totalTime.percentDurationEachOperatorSms[i];
            }
            
            ViewBag.DateFirst = DateFirst;
            ViewBag.DateLast = DateLast;
            ViewBag.Service = Service;
            ViewBag.Type = Type;
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult ShowChartSms()
        {
            clearListClass.TransformListInClearList();
            resultSelectInList = clearListClass.clearList.Select(n => n).ToList();
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ShowChartSms(string Service, string Type, DateTime DateFirst, DateTime DateLast)
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
            TotalTime totalTime = new TotalTime(resultSelectInList);
            totalTime.SummarizeDurationPercentOperator();
            ViewBag.DurationSms = new double[5];
            ViewBag.PercentDurationSms = new double[5];
            for (int i = 0; i < 5; i++)
            {
                ViewBag.DurationSms[i] = totalTime.durationEachOperatorSms[i];
                ViewBag.PercentDurationSms[i] = totalTime.percentDurationEachOperatorSms[i];
            }

            ViewBag.DateFirst = DateFirst;
            ViewBag.DateLast = DateLast;
            ViewBag.Service = Service;
            ViewBag.Type = Type;
            return PartialView();
        }

    }
}
