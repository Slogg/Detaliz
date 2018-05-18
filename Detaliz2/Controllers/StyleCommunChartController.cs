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
    public class StyleCommunChartController : Controller
    {
        // GET: CommunicationStyleChart
        SelectDataInList dataInList = new SelectDataInList();
        public List<SpecificationList> resultSelectInList = new List<SpecificationList>();
        DraftToClear clearListClass = new DraftToClear();
        public List<SpecificationList> resultSelect = new List<SpecificationList>();

        [HttpGet]
        public PartialViewResult ShowChartStyleCommun()
        {
            clearListClass.TransformListInClearList();
            resultSelect = clearListClass.clearList.Select(n => n).ToList();
            return PartialView(resultSelect);
        }
        [HttpPost]
        public PartialViewResult ShowChartStyleCommun(string Service, DateTime DateFirst, DateTime DateLast, string Type)
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
            StyleCommunicationPercent totalTime = new StyleCommunicationPercent(resultSelectInList);
            totalTime.SummarizeDurationPercentOperator();
            ViewBag.DurWeek = new double[2];
            ViewBag.PercDurWeek = new double[2];
            for (int i = 0; i < 2; i++)
            {
                ViewBag.DurWeek[i] = totalTime.durationService[0, i];
                ViewBag.PercDurWeek[i] = totalTime.percentDurationService[0, i];
            }
            ViewBag.Service = Service;
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult ShowChartStyleCommunSms()
        {
            clearListClass.TransformListInClearList();
            resultSelect = clearListClass.clearList.Select(n => n).ToList();
            return PartialView(resultSelect);
        }
        [HttpPost]
        public PartialViewResult ShowChartStyleCommunSms(string Service, DateTime DateFirst, DateTime DateLast, string Type)
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
            StyleCommunicationPercent totalTime = new StyleCommunicationPercent(resultSelectInList);
            totalTime.SummarizeDurationPercentOperator();
            ViewBag.DurWeek = new double[2];
            ViewBag.PercDurWeek = new double[2];
            for (int i = 0; i < 2; i++)
            {
                ViewBag.DurWeek[i] = totalTime.durationService[1, i];
                ViewBag.PercDurWeek[i] = totalTime.percentDurationService[1, i];
            }
            ViewBag.Service = Service;
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult ShowChartStyleCommunInet()
        {
            clearListClass.TransformListInClearList();
            resultSelect = clearListClass.clearList.Select(n => n).ToList();
            return PartialView(resultSelect);
        }
        [HttpPost]
        public PartialViewResult ShowChartStyleCommunInet(string Service, DateTime DateFirst, DateTime DateLast, string Type)
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
            StyleCommunicationPercent totalTime = new StyleCommunicationPercent(resultSelectInList);
            totalTime.SummarizeDurationPercentOperator();
            ViewBag.DurWeek = new double[2];
            ViewBag.PercDurWeek = new double[2];
            for (int i = 0; i < 2; i++)
            {
                ViewBag.DurWeek[i] = totalTime.durationService[2, i];
                ViewBag.PercDurWeek[i] = totalTime.percentDurationService[2, i];
            }
            ViewBag.Service = Service;
            return PartialView();
        }
    }
}
