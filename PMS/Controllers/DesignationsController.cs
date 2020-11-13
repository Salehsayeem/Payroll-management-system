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
    
    public class DesignationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public JsonResult IsDesignationNameAvailable(string designationName)
        {
            return Json(!db.Designations.Any(u => u.DesignationName == designationName), JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin,Manager")]
        // GET: Designations
        public ActionResult Index()
        {
            return View(db.Designations.ToList());
        }
        [Authorize(Roles = "Admin")]
        // GET: Designations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }
        [Authorize(Roles = "Admin")]
        // GET: Designations/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DesignationName")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designation);
                db.SaveChanges();
                //FlashMessage.Confirmation("Added Successfully {0}", designation.DesignationName);
                return RedirectToAction("Index");
            }

            return View(designation);
        }
        [Authorize(Roles = "Admin")]
        // GET: Designations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }
        [Authorize(Roles = "Admin")]
        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DesignationName")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designation);
        }
        [Authorize(Roles = "Admin")]
        // GET: Designations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.Designations.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }
        [Authorize(Roles = "Admin")]
        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designation designation = db.Designations.Find(id);
            db.Designations.Remove(designation);
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
