using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Advance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AdvanceDate { get; set; }
        public string AdvanceReason { get; set; }
        
        [Required(ErrorMessage = "Please enter Amount")]
        public string AdvanceAmount { get; set; }
        public string AdvanceStatus { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
    
}