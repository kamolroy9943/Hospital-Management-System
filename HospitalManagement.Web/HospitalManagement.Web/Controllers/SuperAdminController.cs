using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Hospital.Controllers
{
    public class SuperAdminController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        
        // GET: SuperAdmin
        public ActionResult Index()
        {
            

            return View();
        }
        public ActionResult Details(int id)
        {
            var model = _context.Admins.Find(id);
            return View(model);
        }
        public ActionResult List()
        {
            var model = _context.Admins.ToList();

            return View(model);
        }

        public ActionResult Blocking(int id)
        {
            var model = _context.Admins.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Blocking(int id, AdminRole collection)
        {
            try
            {
                AdminRole Admin = _context.Admins.Find(id);
                
                Admin.IsBlocked = "Blocked";
                Admin.Updated = DateTime.Today;
                Admin.UpdatedBy = User.Identity.Name;

                _context.Entry(Admin).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            catch {
                return View();
            }
        }

        public ActionResult Assignning (int id)
        {
            List<Building> Buildings = _context.Building.ToList();
            ViewBag.Buildinglist = new SelectList(Buildings, "Id", "BuildingName");

            return View();
        }


        [HttpPost]
        public ActionResult Assignning(int id,AdminRole collection)
        {
            try {

                return View();
            }
            catch
            {
                return View();
            }
        }


    }
}