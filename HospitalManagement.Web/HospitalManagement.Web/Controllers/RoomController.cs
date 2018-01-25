using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class RoomController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();

        // GET: Room
        public ActionResult Index(int id)
        {
            var model = _context.Rooms.Where(x => x.FloorId == id).ToList();
            return View(model);
        }

        public ActionResult DashBoard(int id)
        {

            var model = _context.Rooms.Where(x => x.FloorId == id).ToList();
            return View(model);
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            var Seat = _context.Seats.Where(x => x.Where == "Room").ToList();
            var CountSeat = Seat.Count(x => x.WhereID == id);
            ViewBag.RoomId = id;
            ViewBag.CountSeat = CountSeat;

            var model = _context.Rooms.Find(id);
            return View(model);
        }
        public ActionResult RoomToDelete(int whereId)
        {
            return RedirectToAction("Delete", "Seat", new { where = "Ward", whereId = whereId });
        }
        public ActionResult RoomToSeatList(string where,int whereId)
        {
            return RedirectToAction("FromWhereList", "Seat", new { where = "Room", whereid = whereId });
        }
        
        public ActionResult RoomToCreate(string where,int whereId)
        {
            return RedirectToAction("WhereCreate", "Seat", new { where = "Room", whereId = whereId });
        }
        // GET: Room/Create
        public ActionResult Create(int id)
        {
            int Floor = _context.Floors.FirstOrDefault(x => x.Id == id).FloorNumber;
            ViewBag.FloorNumber = Floor;
            ViewBag.FloorId = id;

            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(Room collection,int FloorId,int FloorNumber)
        {
            try
            {
                // TODO: Add insert logic here
                int CurrentRooms = _context.Rooms.Count(x => x.FloorId == FloorId);
                int initial = FloorNumber * 100;
                string initialstr = initial.ToString();
                int LastRoom = CurrentRooms + collection.RoomNumber;
                collection.RoomNumber = 0;
                for(int i=CurrentRooms+1;i<=LastRoom;i++)
                {
                    int NewRoom = int.Parse(initialstr) + i;
                    collection.RoomNumber = NewRoom;

                    collection.FloorId = FloorId;
                    collection.FloorNumber = FloorNumber;
                    collection.Description = "Not Added";
                    collection.Updated = DateTime.Now;
                    collection.UpdatedBy = User.Identity.Name;

                   _context.Rooms.Add(collection);
                    _context.SaveChanges();

                }
                

                return RedirectToAction("Details","Floor",new {id=FloorId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            Room Room = _context.Rooms.Find(id);
            return View(Room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room collection)
        {
            try
            {
                
                var model = _context.Rooms.Find(id);
                model.Description = collection.Description;
                model.Updated = DateTime.Now;
                model.UpdatedBy = User.Identity.Name;

                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("DashBoard","Room",new {id=model.FloorId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
