using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMS.Models;
using CrystalDecisions.CrystalReports.Engine;
using Vereyon.Web;

namespace PMS.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class AdvancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Advances
        public ActionResult Index()
        {
            var advances = db.Advances.Include(a => a.Employee);
            return View(advances.ToList());
        }

        // GET: Advances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advance advance = db.Advances.Find(id);
            if (advance == null)
            {
                return HttpNotFound();
            }
            return View(advance);
        }

        // GET: Advances/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code");
            return View();
        }

        // POST: Advances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdvanceDate,AdvanceReason,AdvanceAmount,AdvanceStatus,EmployeeId")] Advance advance)
        {
            if (ModelState.IsValid)
            {

                db.Advances.Add(advance);
                db.SaveChanges();
                //FlashMessage.Confirmation("Added Successfully {0}", advance.AdvanceReason);
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", advance.EmployeeId);
            return View(advance);
        }

        // GET: Advances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advance advance = db.Advances.Find(id);
            if (advance == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", advance.EmployeeId);
            return View(advance);
        }

        // POST: Advances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdvanceDate,AdvanceReason,AdvanceAmount,AdvanceStatus,EmployeeId")] Advance advance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", advance.EmployeeId);
            return View(advance);
        }

        // GET: Advances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advance advance = db.Advances.Find(id);
            if (advance == null)
            {
                return HttpNotFound();
            }
            return View(advance);
        }

        // POST: Advances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Advance advance = db.Advances.Find(id);
                if (advance != null)
                    db.Advances.Remove(advance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Delete");
            }
            
        }

        ///---------------------------------------------------------------------------------////////////
        ///
        //PDF

        public ActionResult DownloadPdf()
        {

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Advance.rpt"));
            //rd.SetDataSource(advances);
            rd.SetDataSource(db.Advances.Select(c => new
            {
                Id = c.Id,
                Date = c.AdvanceDate,
                Reason = c.AdvanceReason,
                Amount = c.AdvanceAmount,
                Status = c.AdvanceStatus,
                EmployeeId = c.Employee.Code
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);


            return File(stream, "application/pdf", "Advance.pdf");
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
