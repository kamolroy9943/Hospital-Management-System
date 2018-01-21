using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class LabController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: Lab
        public ActionResult Index()
        {
            var model = _context.Labs.ToList();
            return View(model);
        }
        public ActionResult LabDash(string where,int id)
        {
            if(where=="Floor")
            {
                var Labmodel = _context.Labs.Where(x => x.FloorId == id).ToList();
                return View(Labmodel);
            }
            else if(where=="Building")
            {
                var Labmodel = _context.Labs.Where(x => x.BuildingId== id).ToList();
                return View(Labmodel);
            }
            return View();
        }

        // GET: Lab/Details/5
        public ActionResult Details(int id)
        {
            Lab lab = _context.Labs.Find(id);
            return View(lab);
        }

        // GET: Lab/Create
        public ActionResult Create()
        {
            List<Building> Buildings = _context.Building.ToList();
            ViewBag.Buildinglist = new SelectList(Buildings, "Id", "BuildingName");
            return View();
        }

        public JsonResult GetFloorList(int BuildingId)
        {

            _context.Configuration.ProxyCreationEnabled = false;
             List<Floor> FloorList = _context.Floors.Where(x => x.BuildingId == BuildingId).ToList();
            return Json(FloorList, JsonRequestBehavior.AllowGet);
        }

        // POST: Lab/Create
        [HttpPost]
        public ActionResult Create(Lab collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                collection.RoomNumber = _context.Rooms.FirstOrDefault(x => x.Id == collection.RoomId).RoomNumber;
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Labs.Add(collection); _context.SaveChanges();

                Room Room = _context.Rooms.Find(collection.RoomId);
                Room.Description = "Using For " + collection.Name + " Lab";
                _context.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Get
        public ActionResult FromCreate(string where,int id)
        {
            if(where=="Floor")
            {
                var Roomlist1= _context.Rooms.Where(x => x.FloorId == id).ToList();
                
                List<Room> Rooms = new List<Room>();
                foreach (var room in Roomlist1)
                {
                    int xx = room.Id;
                    int y = _context.Labs.Count(x => x.RoomId == xx);
                    if (y == 0) Rooms.Add(room); 
                                    }             

                ViewBag.Roomlist = new SelectList(Rooms, "Id", "RoomNumber");
            }
            else if(where=="Building")
            {
                List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == id).ToList();
                ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");
            }
            ViewBag.What = where;

            return View();
        }

        public JsonResult GetRoomList(int FloorId)
        {

            var Roomlist1 = _context.Rooms.Where(x => x.FloorId == FloorId).ToList();

            List<Room> Rooms = new List<Room>();
            foreach (var room in Roomlist1)
            {
                int xx = room.Id;
                int y = _context.Labs.Count(x => x.RoomId == xx);
                if (y == 0) Rooms.Add(room);
            }

            ViewBag.Roomlist = new SelectList(Rooms, "Id", "RoomNumber");
            _context.Configuration.ProxyCreationEnabled = false;
           // List<Room> RoomList = _context.Rooms.Where(x => x.FloorId == FloorId).ToList();
            return Json(Rooms, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FromCreate(Lab collection,string where, int id)
        {
            try
            {
                if(where=="Floor")
                {
                    collection.FloorId = id;
                    collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == id).FloorNumber;
                    collection.BuildingId = _context.Floors.FirstOrDefault(x => x.Id == id).BuildingId;
                    collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                }
                else if(where=="Building")
                {
                    collection.BuildingId = id;
                    collection.BuildingName= _context.Building.FirstOrDefault(x => x.Id == id).BuildingName;
                    collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                }
                collection.RoomNumber = _context.Rooms.FirstOrDefault(x => x.Id == collection.RoomId).RoomNumber;
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Labs.Add(collection);_context.SaveChanges();

                Room Room = _context.Rooms.Find(collection.RoomId);
                Room.Description = "Using For " + collection.Name + " Lab";
                _context.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();


                if(where=="Floor")
                {
                    return RedirectToAction("Details", "Floor", new { id = id });
                }
                else
                {
                    return RedirectToAction("Details", "Building", new { id = id });
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Lab/Edit/5
        public ActionResult Edit(int id)
        {
            Lab lab = _context.Labs.Find(id);
            return View(lab);
        }

        // POST: Lab/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Lab collection)
        {
            try
            {
                // TODO: Add update logic here
                Lab model = _context.Labs.Find(id);
                model.Name = collection.Name;
                model.Description = collection.Description;
                model.Updated = DateTime.Now;
                model.UpdatedBy = User.Identity.Name;

                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;_context.SaveChanges();

                Room Room = _context.Rooms.Find(model.RoomId);
                Room.Description = "Using For " + collection.Name + " Lab";
                _context.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lab/Delete/5
        public ActionResult Delete(int id)
        {
            Lab lab = _context.Labs.Find(id);
            return View(lab);
        }

        // POST: Lab/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Lab lab = _context.Labs.Find(id);
                _context.Labs.Remove(lab);_context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
