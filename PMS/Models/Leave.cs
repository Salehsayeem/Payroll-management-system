using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }

        public string LeaveName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        [Required(ErrorMessage = "What is the Reason?")]
        public string LeaveReason { get; set; }
        public string LeaveStatus { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}