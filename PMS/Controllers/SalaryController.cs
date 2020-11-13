using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMS.Models;
using PMS.ViewModel;

namespace PMS.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class SalaryController : Controller
    {
        // GET: Salary
        public ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            List<SalaryVM> salaryVMList = new List<SalaryVM>();
            //var salary = (from a in db.Advances
            //              join e in db.Employees on a.EmployeeId equals e.Id
            //              join s in db.Schedules on e.ScheduleId equals s.Id
            //              join d in db.Departments on e.DepartmentId equals d.Id
            //              from de in db.Deductions
            //              join ded in db.Employees on de.EmployeeId equals ded.Id
            //              from o in db.Overtimes
            //              join ov in db.Employees on o.EmployeeId equals ov.Id


            //              select new
            //    {

            //        e.Code,
            //        e.Name,
            //        e.Basic,
            //        a.AdvanceAmount,
            //        a.AdvanceReason,
            //        s.ShiftName,
            //        d.DepartmentName,
            //        de.DeductionAmount,
            //        o.TotalAmount


            //    }).ToList();
            //foreach (var item in salary)
            //{
            //    SalaryVM objSalary = new SalaryVM();
            //    objSalary.Code = item.Code;
            //    objSalary.Name = item.Name;
            //    objSalary.Basic = item.Basic;
            //    objSalary.Shift = item.ShiftName;
            //    objSalary.Amount = item.AdvanceAmount;
            //    objSalary.Department = item.DepartmentName;
            //    objSalary.DeductionAmount = item.DeductionAmount;
            //    objSalary.OvertimeAmount = item.TotalAmount;
            //    salaryVMList.Add(objSalary);



            //}
            var salary = (from e in db.Employees
                          join a in db.Advances on e.Id equals a.EmployeeId
                          join de in db.Deductions on e.Id equals de.EmployeeId
                          join o in db.Overtimes on e.Id equals o.EmployeeId
                          select new
                          {
                              e.Code,
                              e.Name,
                              e.Basic,
                              a.AdvanceAmount,
                              de.DeductionAmount,
                              o.TotalAmount

                          }).ToList();
            foreach (var item in salary)
            {
                
                SalaryVM objSalary = new SalaryVM();
                objSalary.Code = item.Code;
                objSalary.Name = item.Name;
                objSalary.Basic = item.Basic;
                objSalary.Amount = item.AdvanceAmount;
                objSalary.DeductionAmount = item.DeductionAmount;
                objSalary.OvertimeAmount = item.TotalAmount;
                salaryVMList.Add(objSalary);

                
                
                
            }
            return View(salaryVMList);
        }
    }
}