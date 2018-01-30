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

        public ActionResult AssignToFloor(int id)
        {                 
            List<Building> Buildings = _context.Building.ToList();
            ViewBag.Buildinglist = new SelectList(Buildings, "Id", "BuildingName");

            var model = _context.Admins.Find(id);
            return View(model);
        }
        public JsonResult GetFloorList(int BuildingId)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            List<Floor> FloorList = _context.Floors.Where(x => x.BuildingId == BuildingId).ToList();
            return Json(FloorList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AssignToFloor(int id,AdminRole collection)
        {
            try {
                AdminRole Admin = _context.Admins.Find(id);
                Admin.BuildingId = collection.BuildingId;
                Admin.PostId = collection.PostId;
                string BuildingName = _context.Building.FirstOrDefault(x => x.Id ==collection.BuildingId).BuildingName;
                int FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.PostId).FloorNumber;
                Admin.IsAssigned = BuildingName + "( " + FloorNumber.ToString() + " )";
                Admin.Updated = DateTime.Today;
                Admin.UpdatedBy = User.Identity.Name;

                _context.Entry(Admin).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AssignToCounter(int id)
        {
            List<Building> Buildings = _context.Building.ToList();
            ViewBag.Buildinglist = new SelectList(Buildings, "Id", "BuildingName");

            var model = _context.Admins.Find(id);
            return View(model);
        }
        public JsonResult GetCounterList(int BuildingId)
        {

            _context.Configuration.ProxyCreationEnabled = false;
            List<Ticket_Counter> List = _context.TicketCounter.Where(x => x.BuildingId == BuildingId).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AssignToCounter(int id, AdminRole collection)
        {
            try
            {
                AdminRole Admin = _context.Admins.Find(id);
                Admin.BuildingId = collection.BuildingId;
                Admin.PostId = collection.PostId;
                string BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                int CounterNumber = _context.TicketCounter.FirstOrDefault(x => x.Id == collection.PostId).Number;
                Admin.IsAssigned = BuildingName + "( " + CounterNumber.ToString() + " )";
                Admin.Updated = DateTime.Today;
                Admin.UpdatedBy = User.Identity.Name;

                _context.Entry(Admin).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult AssignToLab(int id)
        {
            List<Building> Buildings = _context.Building.ToList();
            ViewBag.Buildinglist = new SelectList(Buildings, "Id", "BuildingName");

            var model = _context.Admins.Find(id);
            return View(model);
        }
        public JsonResult GetLabList(int BuildingId)
        {

            _context.Configuration.ProxyCreationEnabled = false;
            List<Lab> List = _context.Labs.Where(x => x.BuildingId == BuildingId).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AssignToLab(int id, AdminRole collection)
        {
            try
            {
                AdminRole Admin = _context.Admins.Find(id);
                Admin.BuildingId = collection.BuildingId;
                Admin.PostId = collection.PostId;
                string BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                int CounterNumber = _context.TicketCounter.FirstOrDefault(x => x.Id == collection.PostId).Number;
                Admin.IsAssigned = BuildingName + "( " + CounterNumber.ToString() + " )";
                Admin.Updated = DateTime.Today;
                Admin.UpdatedBy = User.Identity.Name;

                _context.Entry(Admin).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }


    }
}