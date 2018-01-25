using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class FloorController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();

        // GET: Floor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard(int id)
        {
            var building = _context.Building.ToList();
            string BuildingName = building.FirstOrDefault(x => x.Id == id).BuildingName;
            ViewBag.Building = BuildingName;

            var floor = _context.Floors.Where(x => x.BuildingId == id).ToList();

            return View(floor);
        }

        public ActionResult FloorToDepartmentList(int id)
        {

            return RedirectToAction("FromFloorDash", "Department", new { id = id });
        }

        public ActionResult FloorToAddDepartment(int id)
        {

            return RedirectToAction("FromFloorCreate", "Department", new { id = id });
        }

        public ActionResult FloorToRoomList(int id)
        {
            return RedirectToAction("DashBoard", "Room", new { id = id });
        }

        public ActionResult FloorToAddRoom(int id)
        {

            return RedirectToAction("Create", "Room", new { id = id });
        }

        public ActionResult FloorToWardList(int id)
        {
            return RedirectToAction("FromFloorDash", "Ward", new { id = id });
        }

        public ActionResult FloorToAddWard(int id)
        {
            return RedirectToAction("FromFloorCreate", "Ward", new { id = id });
        }

        public ActionResult FloorToOperationTheaterDash(int id)
        {
            return RedirectToAction("FromFloorDash", "OperationTheater", new { id = id });
        }

        public ActionResult FloorToAddOperationTheater(int id)
        {
            return RedirectToAction("FromFloorCreate", "OperationTheater", new { id = id });
        }

        public ActionResult FloorToLabDash(int id)
        {
            return RedirectToAction("LabDash", "Lab", new {where="Floor",id=id });
        }
        public ActionResult FloorToAddLab(int id)
        {
            return RedirectToAction("FromCreate", "Lab", new { where="Floor",id = id });
        }

        // GET: Floor/Details/5
        public ActionResult Details(int id)
        {
            Floor floor = _context.Floors.Find(id);

            var fmodel = _context.Floors.Where(x => x.Id == id);
            var bmodel = _context.Building.ToList();

            int B_id = fmodel.FirstOrDefault(x => x.Id == id).BuildingId;
            string building = bmodel.FirstOrDefault(x => x.Id == B_id).BuildingName;
            ViewBag.BuildingName = building;
            ViewBag.BuildingId = B_id;

            int Departments = _context.Departments.Count(x => x.FloorId == id);
            ViewBag.Departments = Departments;

            int Rooms = _context.Rooms.Count(x => x.FloorId == id);
            ViewBag.Rooms = Rooms;

            int Wards = _context.Wards.Count(x => x.FloorId == id);
            ViewBag.Wards = Wards;

            int countOTs = _context.OpertionTheaters.Count(x => x.FloorId == id);
            ViewBag.OTs = countOTs;
            int CountSeat = _context.Seats.Count(x => x.FloorId == id);
            ViewBag.Seats = CountSeat;

            int CountLabs = _context.Labs.Count(x => x.FloorId == id);
            ViewBag.Labs = CountLabs;

            return View(floor);
        }

        // GET: Floor/Create
        public ActionResult Create(int id)
        {
            var floor = _context.Floors.ToList();
            int count = floor.Count(x => x.BuildingId == id);
            ViewBag.Floors = count;

            var building = _context.Building.ToList();
            string BuildingName = building.FirstOrDefault(x => x.Id == id).BuildingName;
            ViewBag.Building = BuildingName;
            ViewBag.BuildingId = id;

            return View();
        }

        // POST: Floor/Create
        [HttpPost]
        public ActionResult Create(Floor collection,int id)
        {
            try
            {
                var floor = _context.Floors.ToList();
                int count = floor.Count(x => x.BuildingId == id);
                
                int a = collection.FloorNumber; 
                int b = count + a;

               
                for(int i=count+1;i<=b;i++)
                {
                    collection.BuildingId = id;
                    collection.FloorNumber = i;
                    _context.Floors.Add(collection);
                    _context.SaveChanges();
                }
                //..............................
                Building building = _context.Building.Find(id);
                building.Updated = DateTime.Now;
                building.UpdatedBy = User.Identity.Name;
                _context.Entry(building).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();



                return RedirectToAction("Details","Building",new {id=id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Floor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Floor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Floor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Floor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var model = _context.Icu.Find(id);
                _context.Icu.Remove(model);
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
