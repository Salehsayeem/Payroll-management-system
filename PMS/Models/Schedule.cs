using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Shift name")]
        public string ShiftName { get; set; }
        [Required]
        public string StartTIme { get; set; }
        [Required]
        public string EndTime { get; set; }

    }
}