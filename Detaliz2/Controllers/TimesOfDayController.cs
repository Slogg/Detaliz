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
    public class TimesOfDayController : Controller
    {
        // GET: TimesOfDay
        SelectDataInList dataInList = new SelectDataInList();
        public List<SpecificationList> resultSelectInList = new List<SpecificationList>();
        DraftToClear clearListClass = new DraftToClear();
        public List<SpecificationList> resultSelect = new List<SpecificationList>();

        [HttpGet]
        public PartialViewResult ShowChartTOfDCall()
        {
            clearListClass.TransformListInClearList();
            resultSelect = clearListClass.clearList.Select(n => n).ToList();
            return PartialView(resultSelect);
        }
        [HttpPost]
        public PartialViewResult ShowChartTOfDCall(string Service, DateTime DateFirst, DateTime DateLast, string Type)
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
            TimesOfDayPercent totalTime = new TimesOfDayPercent(resultSelectInList);
            totalTime.DetermineProcentTimesOfDay();
            ViewBag.DurTOfD = new double[4];
            ViewBag.PercDurTOfD = new double[4];
            for (int i = 0; i < 4; i++)
            {
                ViewBag.DurTOfD[i] = totalTime.durationService[0, i];
                ViewBag.PercDurTOfD[i] = totalTime.percentDurationService[0, i];
            }
            ViewBag.Service = Service;
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult ShowChartTOfDSms()
        {
            clearListClass.TransformListInClearList();
            resultSelect = clearListClass.clearList.Select(n => n).ToList();
            return PartialView(resultSelect);
        }
        [HttpPost]
        public PartialViewResult ShowChartTOfDSms(string Service, DateTime DateFirst, DateTime DateLast, string Type)
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
            TimesOfDayPercent totalTime = new TimesOfDayPercent(resultSelectInList);
            totalTime.DetermineProcentTimesOfDay();
            ViewBag.DurTOfD = new double[4];
            ViewBag.PercDurTOfD = new double[4];
            for (int i = 0; i < 4; i++)
            {
                ViewBag.DurTOfD[i] = totalTime.durationService[1, i];
                ViewBag.PercDurTOfD[i] = totalTime.percentDurationService[1, i];
            }
            ViewBag.Service = Service;
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult ShowChartTOfDWeb()
        {
            clearListClass.TransformListInClearList();
            resultSelect = clearListClass.clearList.Select(n => n).ToList();
            return PartialView(resultSelect);
        }
        [HttpPost]
        public PartialViewResult ShowChartTOfDWeb(string Service, DateTime DateFirst, DateTime DateLast, string Type)
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
            TimesOfDayPercent totalTime = new TimesOfDayPercent(resultSelectInList);
            totalTime.DetermineProcentTimesOfDay();
            ViewBag.DurTOfD = new double[4];
            ViewBag.PercDurTOfD = new double[4];
            for (int i = 0; i < 4; i++)
            {
                ViewBag.DurTOfD[i] = totalTime.durationService[2, i];
                ViewBag.PercDurTOfD[i] = totalTime.percentDurationService[2, i];
            }
            ViewBag.Service = Service;
            return PartialView();
        }
    }
}