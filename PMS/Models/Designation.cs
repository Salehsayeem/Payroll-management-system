using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Remote("IsDesignationNameAvailable", "Designations", ErrorMessage = "Designation Name  Already Available")]

        public string DesignationName { get; set; }
    }
}