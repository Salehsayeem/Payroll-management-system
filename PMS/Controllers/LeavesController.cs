﻿using System;
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
    public class LeavesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Leaves
        public ActionResult Index()
        {
            var leaves = db.Leaves.Include(l => l.Employee);
            return View(leaves.ToList());
        }

        // GET: Leaves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave leave = db.Leaves.Find(id);
            if (leave == null)
            {
                return HttpNotFound();
            }
            return View(leave);
        }

        // GET: Leaves/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LeaveName,StartDate,EndDate,LeaveReason,LeaveStatus,EmployeeId")] Leave leave)
        {
            if (leave != null)
            {
                if (ModelState.IsValid)
                {
                    db.Leaves.Add(leave);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", leave.EmployeeId);
            }
            return View(leave);
        }

        // GET: Leaves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave leave = db.Leaves.Find(id);
            if (leave == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", leave.EmployeeId);
            return View(leave);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LeaveName,StartDate,EndDate,LeaveReason,LeaveStatus,EmployeeId")] Leave leave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Code", leave.EmployeeId);
            return View(leave);
        }

        // GET: Leaves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave leave = db.Leaves.Find(id);
            if (leave == null)
            {
                return HttpNotFound();
            }
            return View(leave);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leave leave = db.Leaves.Find(id);
            db.Leaves.Remove(leave);
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
