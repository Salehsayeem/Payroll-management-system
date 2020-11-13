using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Models;

namespace PMS.ViewModel
{
    public class SalaryVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Basic { get; set; }
        public string Amount { get; set; }
        public string Shift { get; set; }
        public string Department { get; set; }
        public string DeductionAmount { get; set; }
        public string OvertimeAmount { get; set; }



    }
}