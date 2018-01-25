using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class WardController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();

        // GET: Ward
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FromDepartmentDash(int id)
        {
           var Ward = _context.Wards.Where(x => x.DepartmentId == id).ToList();
            ViewBag.DepartmentName = _context.Departments.FirstOrDefault(x => x.Id == id).Name;
            ViewBag.FloorNumber = _context.Departments.FirstOrDefault(x => x.Id == id).FloorNumber;
            ViewBag.Building = _context.Departments.FirstOrDefault(x => x.Id == id).BuildingName;
            ViewBag.DepartmentId = id;
            return View(Ward);
        }

        public ActionResult FromFloorDash(int id)
        {
            var Ward = _context.Wards.Where(x => x.FloorId == id).ToList();
            ViewBag.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == id).FloorNumber;
            ViewBag.BuildingName = _context.Building.FirstOrDefault(x => x.Id == (_context.Floors.FirstOrDefault(y=> y.Id == id).BuildingId)).BuildingName;
            ViewBag.FloorId = id;

            return View(Ward);
        }

        public ActionResult FromBuildingDash(int id)
        {
            var Ward = _context.Wards.Where(x => x.BuildingId == id).ToList();
            ViewBag.BuildingName = _context.Building.FirstOrDefault(x => x.Id == id).BuildingName;
            ViewBag.BuildingId = id;
            return View(Ward);
        }
        // GET: Ward/Details/5
        public ActionResult Details(int id)
        {
            var Seat = _context.Seats.Where(x => x.Where == "Ward").ToList();
            var CountSeat = Seat.Count(x => x.WhereID == id);
            ViewBag.WardId = id;
            ViewBag.CountSeat = CountSeat;

            Ward ward = _context.Wards.Find(id);
            ViewBag.BuildingName = _context.Building.FirstOrDefault(x => x.Id == ward.BuildingId).BuildingName;
            return View(ward);
        }

        public ActionResult WardToDelete(int whereId)
        {
            return RedirectToAction("Delete", "Seat", new { where = "Ward", whereId = whereId });
        }

        public ActionResult WardToSeatList(int whereId)
        {
            return RedirectToAction("FromWhereList", "Seat", new { where = "Ward", whereId = whereId });
        }

        public ActionResult WardToCreate(int whereId)
        {
            return RedirectToAction("WhereCreate", "Seat", new { where = "Ward",whereId = whereId });
        }

        // GET: Ward/Create
        public ActionResult FromDepartmentCreate(int id)
        {
            int BuildingId = _context.Departments.FirstOrDefault(x => x.Id == id).BuildingId;
            List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == BuildingId).ToList();
            ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");
            ViewBag.DepartmentId = id;
            return View();
        }

        // POST: Ward/Create
        [HttpPost]
        public ActionResult FromDepartmentCreate(Ward collection,int id)
        {
            try
            {
                if(collection.FloorId==0)
                {
                    int BuildingId = _context.Departments.FirstOrDefault(x => x.Id == id).BuildingId;
                    List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == BuildingId).ToList();
                    ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");
                    ViewBag.DepartmentId = id;
                    return View(collection);
                }

                // TODO: Add insert logic here
                collection.DepartmentId = id;
                collection.DepartmentName = _context.Departments.FirstOrDefault(x => x.Id == id).Name;
                //collection.FloorId = _context.Departments.FirstOrDefault(x => x.Id == id).FloorId;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                collection.BuildingId = _context.Departments.FirstOrDefault(x => x.Id == id).BuildingId;
                collection.Updated = DateTime.Now;
                collection.Updatedby = User.Identity.Name;

                _context.Wards.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("FromDepartmentDash","Ward",new {id=id });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FromFloorCreate(int id)
        {
            ViewBag.FloorId = id;
            int BuildingId = _context.Floors.FirstOrDefault(x => x.Id == id).BuildingId;
            List<Department> Departments = _context.Departments.Where(x => x.BuildingId == BuildingId).ToList();
            ViewBag.Departmentlist = new SelectList(Departments, "Id", "Name");
            return View();
        }

        // POST: Ward/Create
        [HttpPost]
        public ActionResult FromFloorCreate(Ward collection,int id)
        {
            try
            {
                if(collection.DepartmentId==0)
                {
                    int BuildingId = _context.Floors.FirstOrDefault(x => x.Id == id).BuildingId;
                    List<Department> Departments = _context.Departments.Where(x => x.BuildingId ==BuildingId).ToList();
                    ViewBag.Departmentlist = new SelectList(Departments, "Id", "Name");
                    ViewBag.FloorId = id;
                    return View(collection);
                }

                // TODO: Add insert logic here
                collection.FloorId = id;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == id).FloorNumber;
                 collection.DepartmentName = _context.Departments.FirstOrDefault(x => x.Id == collection.DepartmentId).Name;
                collection.BuildingId = _context.Floors.FirstOrDefault(x => x.Id == id).BuildingId;
                collection.Updated = DateTime.Now;
                collection.Updatedby = User.Identity.Name;

                _context.Wards.Add(collection); _context.SaveChanges();
                return RedirectToAction("FromFloorDash","Ward",new {id=id });
            }
            catch
            {
                return View();
            }
        }


        public ActionResult FromBuildingCreate(int id)
        {
            List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == id).ToList();
            ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");

            List<Department> Departments = _context.Departments.Where(x => x.BuildingId == id).ToList();
            ViewBag.Departmentlist = new SelectList(Departments, "Id", "Name");

            ViewBag.BuildingId = id;
            ViewBag.BuildingName = _context.Building.FirstOrDefault(x => x.Id == id).BuildingName;
            return View();
        }

        // POST: Ward/Create
        [HttpPost]
        
        public ActionResult FromBuildingCreate(Ward collection,int id)
        {
            try
            {
                if (collection.FloorId == 0 || collection.DepartmentId == 0)
                {
                    List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == id).ToList();
                    ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");
                    ViewBag.BuildingId = id;
                    List<Department> Departments = _context.Departments.Where(x => x.BuildingId == id).ToList();
                    ViewBag.Departmentlist = new SelectList(Departments, "Id", "Name");
                    return View(collection);
                }

                collection.BuildingId = id;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                collection.DepartmentName = _context.Departments.FirstOrDefault(x => x.Id == collection.DepartmentId).Name;
                collection.Updated = DateTime.Now;
                collection.Updatedby = User.Identity.Name;

               

                _context.Wards.Add(collection);_context.SaveChanges();

                return RedirectToAction("Details","Building",new { id=id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Ward/Edit/5
        public ActionResult Edit(int id, string from, int fromid)
        {
            ViewBag.from = from; ViewBag.fromid = fromid;
            var Ward = _context.Wards.Find(id);
            return View(Ward);
        }

        // POST: Ward/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Ward collection, string from, int fromid)
        {
            try
            {
                // TODO: Add update logic here
                Ward ward = _context.Wards.Find(id);
                ward.Name = collection.Name;
                ward.Updated = DateTime.Now;
                ward.Updatedby = User.Identity.Name;

                _context.Entry(ward).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                string Return = "From" + from + "Dash";
                return RedirectToAction(Return, "Ward", new { id = fromid });
            }
            catch
            {
                return View();
            }
        }

        // GET: Ward/Delete/5
        public ActionResult Delete(int id,string from,int fromid)
        {
            ViewBag.from = from;ViewBag.fromid = fromid;
            var Ward = _context.Wards.Find(id);
            return View(Ward);
        }

        // POST: Ward/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Ward collection,string from,int fromid)
        {
            try
            {
                Ward ward = _context.Wards.Find(id);
                _context.Wards.Remove(ward);
                _context.SaveChanges();
                string Return = "From" + from + "Dash";
                 return RedirectToAction(Return,"Ward",new {id=fromid });
            }
            catch
            {
                return View();
            }
        }
    }
}
