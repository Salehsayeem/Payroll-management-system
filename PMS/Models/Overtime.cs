using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Overtime
    {
        [Key]
        public int Id { get; set; }

        public string OvertimeDate { get; set; }
        [Required(ErrorMessage = "How many hours ??")]
        public string TotalHour { get; set; }
        [Required(ErrorMessage = "Enter rate per hour please...")]
        public string RatePerHour { get; set; }
        public string OvertimeStatus { get; set; }
        public string TotalAmount { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}