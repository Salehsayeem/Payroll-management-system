using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using PMS.Models;
using Vereyon.Web;

namespace PMS.Controllers
{
    
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        [Authorize(Roles = "Admin,Manager")]
        // GET: Role
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
           // FlashMessage.Confirmation("Added Successfully {0}", Role.Name);
            return RedirectToAction("Index");
        }

        

        
    }
}