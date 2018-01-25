using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Web.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Web.Controllers
{
    public class BuildingController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        
        // GET: Building
        public ActionResult Index()
        {
            var model = _context.Building.ToList();
            return View(model);
        }

        // Building DashBoard
        public ActionResult Dashboard()
        {
            var model = _context.Building.ToList();
            return View(model);
        }

        // GET: Building/Details/5
        public ActionResult Details(int id)
        {
            var floor = _context.Floors.ToList();
            int countfloor = floor.Count(x => x.BuildingId == id);
            ViewBag.Floors = countfloor;

            var dept = _context.Departments.ToList();
            int countdept = dept.Count(x => x.BuildingId == id);
            ViewBag.Departments = countdept;

            int countward = _context.Wards.Count(x => x.BuildingId == id);
            ViewBag.Wards = countward;

            int counticketcounter = _context.TicketCounter.Count(x => x.BuildingId == id);
            ViewBag.TicketCounter = counticketcounter;

            int countOTs = _context.OpertionTheaters.Count(x => x.BuildingId == id);
            ViewBag.OTs = countOTs;

            ViewBag.CountIcu = _context.Icu.Count(x => x.BuildingId == id);
            if (ViewBag.CountIcu != 0) { ViewBag.IcuName = _context.Icu.FirstOrDefault(x => x.BuildingId == id).ICUName; }

            int CountSeat = _context.Seats.Count(x => x.BuildingId == id);
            ViewBag.Seats = CountSeat;

            int CounLab = _context.Labs.Count(x => x.BuildingId == id);
            ViewBag.Labs = CounLab;

            Building B = _context.Building.Find(id);
            return View(B);
        }
        public ActionResult BuildingToLabDash(int id)
        {
            return RedirectToAction("LabDash", "Lab", new { where = "Building", id = id });
        }

        public ActionResult BuildingToAddLab(int id)
        {
            return RedirectToAction("FromCreate", "Lab", new { where="Building",id=id});
        }
        public ActionResult BuildingToWhere(int id,string where)
        {
            if(where=="ICU")
            {
                int ICUId = _context.Icu.FirstOrDefault(x => x.BuildingId == id).Id;
                return RedirectToAction("WhereCreate", "Seat",new {where="ICU",whereId=ICUId });
            }
            else if(where=="Room")
            {
                return RedirectToAction("WhereToCreate", "Seat", new { BuildingId = id, where = "Room" });
            }
            else if(where=="Ward")
            {
                return RedirectToAction("WhereToCreate", "Seat", new { BuildingId = id, where = "Ward" });
            }
            return View();
        }

        public ActionResult BuildingToDetail(int id)
        {
            return RedirectToAction("FromBuildingDetails", "ICU", new { id = id });
        }

        public ActionResult BuildingToCreate(int id)
        {
            return RedirectToAction("FromBuildingCreate", "ICU", new { id = id });
        }

        public ActionResult BuildingToAddFloor(int id)
        {

            return RedirectToAction("Create", "Floor", new { id = id });
        }

        public ActionResult BuildingToFloorDash(int id)
        {

            return RedirectToAction("Dashboard", "Floor", new { id = id });
        }

        public ActionResult BuildingToDepartmentList(int id)
        {

            return RedirectToAction("List", "Department", new { id = id });
        }

        public ActionResult BuildingToAddDepartment(int id)
        {

            return RedirectToAction("Create", "Department", new { id = id });
        }

        public ActionResult BuildingToWardList(int id)
        {
            return RedirectToAction("FromBuildingDash", "Ward", new { id = id });
        }

        public ActionResult BuildingToAddWard(int id)
        {
            return RedirectToAction("FromBuildingCreate", "Ward", new { id = id });
        }

        public ActionResult BuildingToCounterList(int id)
        {
            return RedirectToAction("FromBuildingDash", "TicketCounter", new { id = id });
        }

        public ActionResult BuildingToAddCounter(int id)
        {
            return RedirectToAction("FromBuildingCreate", "TicketCounter",new {id=id });
        }

        public ActionResult BuildingToOperationTheaterDash(int id)
        {
            return RedirectToAction("FromBuildingDash", "OperationTheater", new { id = id });
        }

        public ActionResult BuildingToAddOperationTheater(int id)
        {
            return RedirectToAction("FromBuildingCreate", "OperationTheater", new { id = id });
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Building/Create
        [HttpPost]
        public ActionResult Create(Building collection)
        {
            try
            {
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Building.Add(collection);
                _context.SaveChanges();

               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Building/Edit/5
        public ActionResult Edit(int id)
        {
             Building B = _context.Building.Find(id);
             return View(B);
        }

        // POST: Building/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Building collection)
        {
            try
            {
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Building/Delete/5
        public ActionResult Delete(int id)
        {
            Building B = _context.Building.Find(id);
            return View(B);
        }

        // POST: Building/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Building collection)
        {
            try
            {
                Building B = _context.Building.Find(id);
                _context.Building.Remove(B);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
