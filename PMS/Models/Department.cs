using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Remote("IsDepartmentNameAvailable", "Departments", ErrorMessage = "Department Name Already Available")]
        public string DepartmentName { get; set; }
        [Required]
        [Remote("IsDepartmentCodeAvailable", "Departments", ErrorMessage = "Department Code Already Available")]
        public string DepartmentCode { get; set; }
    }
}