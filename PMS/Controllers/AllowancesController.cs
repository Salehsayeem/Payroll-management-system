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
    public class AllowancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Allowances
        public ActionResult Index()
        {
            return View(db.Allowances.ToList());
        }

        // GET: Allowances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allowance allowance = db.Allowances.Find(id);
            if (allowance == null)
            {
                return HttpNotFound();
            }
            return View(allowance);
        }

        // GET: Allowances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Allowances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AllowanceType,AllowanceAmount,AllowanceStatus")] Allowance allowance)
        {
            if (ModelState.IsValid)
            {
                db.Allowances.Add(allowance);
                db.SaveChanges();
                //FlashMessage.Confirmation("Added Successfully {0}", allowance.AllowanceType);
                return RedirectToAction("Index");
            }

            return View(allowance);
        }

        // GET: Allowances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allowance allowance = db.Allowances.Find(id);
            if (allowance == null)
            {
                return HttpNotFound();
            }
            return View(allowance);
        }

        // POST: Allowances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AllowanceType,AllowanceAmount,AllowanceStatus")] Allowance allowance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allowance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allowance);
        }

        // GET: Allowances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allowance allowance = db.Allowances.Find(id);
            if (allowance == null)
            {
                return HttpNotFound();
            }
            return View(allowance);
        }

        // POST: Allowances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allowance allowance = db.Allowances.Find(id);
            db.Allowances.Remove(allowance);
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

        //---------------------------------------------------------------------------------////////////
        ///
        //PDF

        public ActionResult DownloadPdf()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Allowance.rpt"));
            
            rd.SetDataSource(db.Allowances.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);


            return File(stream, "application/pdf", "Allowance.pdf");
        }
    }
}
