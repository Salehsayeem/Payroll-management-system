using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using PMS.Models;
using Vereyon.Web;

namespace PMS.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult IsPhoneAvailable(string phone)
        {
            return Json(!db.Employees.Any(u => u.Phone == phone), JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsEmailAvailable(string email)
        {
            return Json(!db.Employees.Any(u => u.Email == email), JsonRequestBehavior.AllowGet);
        }
        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Allowance).Include(e => e.Department).Include(e => e.Designation).Include(e => e.Schedule);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.AllowanceId = new SelectList(db.Allowances, "Id", "AllowanceType");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName");
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "ShiftName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Code = GetEmployeeCode(employee);
                db.Employees.Add(employee);
                db.SaveChanges();
                //FlashMessage.Confirmation("Added Successfully {0}", employee.Code);
                return RedirectToAction("Index");
            }

            ViewBag.AllowanceId = new SelectList(db.Allowances, "Id", "AllowanceType", employee.AllowanceId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "ShiftName", employee.ScheduleId);
            return View(employee);
        }

        public string GetEmployeeCode(Employee aEmployee)
        {
            var employeeCount = db.Employees.Count(m => (m.DepartmentId == aEmployee.DepartmentId)) + 1;
            var aDepartment = db.Departments.FirstOrDefault(m => m.Id == aEmployee.DepartmentId);

            string leadingZero = "";
            int length = 3 - employeeCount.ToString().Length;
            for (int i = 0; i < length; i++)
            {
                leadingZero += "0";
            }

            string employeeCode = aDepartment.DepartmentCode + "-" + leadingZero + "-" + DateTime.Now.Year + employeeCount;
            return employeeCode;
        }
        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllowanceId = new SelectList(db.Allowances, "Id", "AllowanceType", employee.AllowanceId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "ShiftName", employee.ScheduleId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllowanceId = new SelectList(db.Allowances, "Id", "AllowanceType", employee.AllowanceId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "ShiftName", employee.ScheduleId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DownloadPdf()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Employees.rpt"));

            rd.SetDataSource(db.Employees.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Employees.pdf");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
