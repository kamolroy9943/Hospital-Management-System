using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class DepartmentController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: Department
        public ActionResult Index()
        {
            var model = _context.Departments.ToList();
            return View(model);
        }

        public ActionResult FromFloorDash(int id)
        {
            var DeptModel = _context.Departments.Where(x => x.FloorId == id).ToList();
            return View(DeptModel);
        }


        public ActionResult List(int id)
        {
            var building = _context.Building.ToList();
            string BuildingName = building.FirstOrDefault(x => x.Id == id).BuildingName;
            ViewBag.Building = BuildingName;

            var department = _context.Departments.Where(x => x.BuildingId == id).ToList();

            return View(department);
        }

        public ActionResult DepartmentToWardList(int id)
        {
            return RedirectToAction("FromDepartmentDash", "Ward", new { id = id });
        }

        public ActionResult DepartmentToAddWard(int id)
        {
            return RedirectToAction("FromDepartmentCreate", "Ward", new { id = id });
        }


        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            Department Dept = _context.Departments.Find(id);

            int Wards = _context.Wards.Count(x => x.DepartmentId == id);
            ViewBag.Wards = Wards;

            return View(Dept);
        }

        // GET: Department/Create
        public ActionResult Create(int id)
        {
            var building = _context.Building.ToList();
            string BuildingName = building.FirstOrDefault(x => x.Id == id).BuildingName;
            ViewBag.Building = BuildingName;
            ViewBag.BuildingId = id;

            List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == id).ToList();
            ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department collection,int id)
        {
            try
            {
                var building = _context.Building.ToList();
                string BuildingName = building.FirstOrDefault(x => x.Id == id).BuildingName;
                ViewBag.Building = BuildingName;

                collection.BuildingId = id;
                collection.BuildingName = BuildingName;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                collection.Updated = DateTime.Now;
                collection.updatedby = User.Identity.Name;

                _context.Departments.Add(collection);
                _context.SaveChanges();

                //.................
                Building Building = _context.Building.Find(id);
                Building.Updated = DateTime.Now;
                Building.UpdatedBy = User.Identity.Name;
                _context.Entry(Building).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Details","Building",new {id=id });
            }
            catch
            {
                return View();
            }
        }


        public ActionResult FromFloorCreate(int id)
        {
            int FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == id).FloorNumber;
            int BuildingId = _context.Floors.FirstOrDefault(x => x.Id == id).BuildingId;
            string BuildingName = _context.Building.FirstOrDefault(x => x.Id == BuildingId).BuildingName;
            ViewBag.BuildingId = BuildingId;
            ViewBag.BuildingName = BuildingName;
            ViewBag.FloorNumber = FloorNumber;
            ViewBag.FloorId = id;

            return View();
        }

        [HttpPost]
        public ActionResult FromFloorCreate(Department collection,int FloorId,int BuildingId)
        {
            try
            {
                collection.BuildingId = BuildingId;
                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == BuildingId).BuildingName;
                collection.FloorId = FloorId;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == FloorId).FloorNumber;
                collection.Updated = DateTime.Now;
                collection.updatedby = User.Identity.Name;

                _context.Departments.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("Details", "Floor", new { id = FloorId });

            }
            catch
            {

            }
            return View();
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            int BuildingId = _context.Departments.FirstOrDefault(x => x.Id == id).BuildingId;

            List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == BuildingId).ToList();
            ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");
            

            var model = _context.Departments.Find(id);
            return View(model);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Department collection)
        {
            try
            {
                // TODO: Add update logic here
                Department dept = _context.Departments.Find(id);

                collection.BuildingId = dept.BuildingId;
                collection.BuildingName = dept.BuildingName;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;

                collection.Updated = DateTime.Now;
                collection.updatedby = User.Identity.Name;

                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            Department Dept = _context.Departments.Find(id);
            return View(Dept);
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Department collection)
        {
            try
            {
                int BuildingID = _context.Departments.FirstOrDefault(x => x.Id == id).BuildingId;
                Department Dept = _context.Departments.Find(id);
                _context.Departments.Remove(Dept);
                _context.SaveChanges();

                // TODO: Add delete logic here

                return RedirectToAction("List",new {id=BuildingID });
            }
            catch
            {
                return View();
            }
        }
    }
}
