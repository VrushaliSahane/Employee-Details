using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Details.Models
{
    public class SalaryModule
    {
        [Key]
        public int ID { get; set; }
        public Decimal Basic { get; set; }
        public Decimal HRA { get; set; }
        public Decimal Travel { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}