using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMS.Models;
using Vereyon.Web;

namespace PMS.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class OvertimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Overtimes
        public ActionResult Index()
        {
            var overtimes = db.Overtimes.Include(o => o.Employee);
            return View(overtimes.ToList());
        }

        // GET: Overtimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Overtime overtime = db.Overtimes.Find(id);
            if (overtime == null)
            {
                return HttpNotFound();
            }
            return View(overtime);
        }

        // GET: Overtimes/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code");
            return View();
        }

        // POST: Overtimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Date,TotalHour,RatePerHour,Status,EmployeeId")] Overtime overtime)
        public ActionResult Create(Overtime overtime)
        {
            if (ModelState.IsValid)
            {
                db.Overtimes.Add(overtime);
                db.SaveChanges();
                //FlashMessage.Confirmation("Added Successfully {0}", overtime.Employee.Code);
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", overtime.EmployeeId);
            return View(overtime);
        }

        // GET: Overtimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Overtime overtime = db.Overtimes.Find(id);
            if (overtime == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", overtime.EmployeeId);
            return View(overtime);
        }

        // POST: Overtimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OvertimeDate,TotalHour,RatePerHour,OvertimeStatus,EmployeeId")] Overtime overtime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(overtime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", overtime.EmployeeId);
            return View(overtime);
        }

        // GET: Overtimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Overtime overtime = db.Overtimes.Find(id);
            if (overtime == null)
            {
                return HttpNotFound();
            }
            return View(overtime);
        }

        // POST: Overtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Overtime overtime = db.Overtimes.Find(id);
            db.Overtimes.Remove(overtime);
            db.SaveChanges();
            return RedirectToAction("Index");
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
