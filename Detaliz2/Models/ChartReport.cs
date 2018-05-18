using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Detaliz2.Models
{
    //необходимо для передачи времени разговора в представление
    //просто передавать double было не правильно, наверно
    public class ChartReport
    {
        public double DurationOperator { get; set; }
        public DateTime DateFirst { get; set; }
        public DateTime DateLast{get;set;}
        public string Type { get; set; }
        public string Service { get; set; }
    }
}