using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Allowance
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter type of allowance")]
        public string AllowanceType { get; set; }
        [Required(ErrorMessage = "Please enter Amount")]
        public string AllowanceAmount { get; set; }
        public string AllowanceStatus { get; set; }

    }
}