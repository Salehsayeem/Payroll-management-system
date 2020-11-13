using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Deduction
    {
        [Key]
        public int Id { get; set; }
        public string DeductionDate { get; set; }
        [Required(ErrorMessage = "What is the reason?")]
        public string DeductionReason { get; set; }
        [Required(ErrorMessage = "Please enter Amount")]
        public string DeductionAmount { get; set; }
        public string DeductionStatus { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}