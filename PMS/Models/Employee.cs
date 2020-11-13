using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter you Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your valid phone number")]
        [Remote("IsPhoneAvailable", "Employees", ErrorMessage = "Phone Number Already exists")]
        public string Phone { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Remote("IsEmailAvailable", "Employees", ErrorMessage = "Email Already exists")]
        public string Email { get; set; }

        [Required]
        public string Basic { get; set; }
        public string Joining { get; set; }
        public string Status { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public int AllowanceId { get; set; }
        public Allowance Allowance { get; set; }


    }

    
    public enum Gender
    {
        Male,
        Female
    }

    public enum Status
    {
        Active,
        InActive
    }
    

    
    

}