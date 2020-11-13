using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime AttendanceDate { get; set; }

        public string AttendanceStatus { get; set; }
        public string AttendanceRemarks { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}