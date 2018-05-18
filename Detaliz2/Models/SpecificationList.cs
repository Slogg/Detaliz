using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Detaliz2.Models
{
    public class SpecificationList
    {
        //свойства списка
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time{ get; set; }
        public string Service { get; set; }
        public double Duration { get; set; }
        public string Type { get; set; }
        public string Operator { get; set; }


    }
}