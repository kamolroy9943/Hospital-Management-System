using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class SeatController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: Seat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FromWhereList(string where,int whereId)
        {

            var modellist = _context.Seats.Where(x => x.Where == where).ToList();
            var model = modellist.Where(x => x.WhereID == whereId).ToList();

            return View(model);
        }
        // GET: Seat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Seat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Seat/Create
        public ActionResult WhereCreate(string where,int whereId)
        {
            var modelist = _context.Seats.Where(x => x.Where == where).ToList();
            int count = modelist.Count(x => x.WhereID == whereId);
            ViewBag.where = where;
            ViewBag.whereId = whereId;
            ViewBag.Message = "There are already " + count.ToString() + " Seats in Here  ";
            return View();
        }

        

        // POST: Seat/Create
        [HttpPost]
        public ActionResult WhereCreate(Seat collection,string where,int whereId)
        {
            try
            {
                // TODO: Add insert logic here
                if(where=="ICU")
                {
                    collection.BuildingId = _context.Icu.FirstOrDefault(x => x.Id == whereId).BuildingId;
                    collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                    collection.FloorId = _context.Icu.FirstOrDefault(x => x.Id == whereId).FloorId;
                    collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;

                }
                else if(where=="Room")
                {
                    collection.FloorId = _context.Rooms.FirstOrDefault(x => x.Id == whereId).FloorId;
                    collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                    collection.BuildingId = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).BuildingId;
                    collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                }
                else if (where=="Ward")
                {
                    collection.BuildingId = _context.Wards.FirstOrDefault(x => x.Id == whereId).BuildingId;
                    collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                    collection.FloorId = _context.Wards.FirstOrDefault(x => x.Id == whereId).FloorId;
                    collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                }
                collection.HasbeenUsed = 0;
                collection.IsEmpty = "Empty";
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                var modelist = _context.Seats.Where(x => x.Where == where).ToList();
                int count = modelist.Count(x => x.WhereID == whereId);
                int add = collection.Number;
                int limit = count + add;

                for(int i=count+1;i<=limit;i++)
                {
                    collection.Number = i;
                    _context.Seats.Add(collection);_context.SaveChanges();
                }

                return RedirectToAction("FromWhereList","Seat",new { where=where,whereId=whereId});
            }
            catch
            {
                return View();
            }
        }


        public ActionResult WhereToCreate(string where, int BuildingId)
        {
            List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == BuildingId).ToList();
            ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");
            ViewBag.BuildingId = BuildingId;
            Seat Seatmodel = new Seat();
            Seatmodel.Where = where;
            

            return View(Seatmodel);
        }

        public JsonResult GetWhereList(int FloorId,string What)
        {
            if (What=="Room")
            {
                List<Room> RoomList = _context.Rooms.Where(x => x.FloorId == FloorId).ToList();
                return Json(RoomList, JsonRequestBehavior.AllowGet);
            }
            else if (What=="Ward")
            {
                List<Ward> WardList = _context.Wards.Where(x => x.FloorId == FloorId).ToList();
                return Json(WardList, JsonRequestBehavior.AllowGet);
            }

            //_context.Configuration.ProxyCreationEnabled = false;
            //List<Floor> FloorList = _context.Floors.Where(x => x.BuildingId == 1).ToList();
            return Json(What, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult WhereToCreate(Seat collection, int BuildingId)
        {
            try
            {
                if(collection.Where=="Room")
                {
                    collection.BuildingId = BuildingId;
                    collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                    collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                }
                else if(collection.Where=="Ward")
                {
                    collection.BuildingId = BuildingId;
                    collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                    collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                }
                collection.HasbeenUsed = 0;
                collection.IsEmpty = "Empty";
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                var modelist = _context.Seats.Where(x => x.Where == collection.Where).ToList();
                int count = modelist.Count(x => x.WhereID == collection.WhereID);
                int add = collection.Number;
                int limit = count + add;

                for (int i = count + 1; i <= limit; i++)
                {
                    collection.Number = i;
                    _context.Seats.Add(collection); _context.SaveChanges();
                }


                return RedirectToAction("FromWhereList", "Seat", new { where =collection.Where, whereId = collection.WhereID });
            }
            catch
            {

                return View();
            }
        }
        // GET: Seat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Seat/Edit/5
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

        // GET: Seat/Delete/5
        public ActionResult Delete(string where,int whereId)
        {
            var Seatmodel = _context.Seats.Where(x => x.Where == where).ToList();
            int Countseat = Seatmodel.Count(x => x.WhereID == whereId);
            ViewBag.Seats = Countseat;

            if (where == "ICU") ViewBag.Message = "We have " + Countseat + " Seats in this ICU";
            else if (where == "Room") ViewBag.Message = "We have " + Countseat + " Seats in this Room";
            else if (where == "Ward") ViewBag.Message = "We have " + Countseat + " Seats in this Ward";

            return View();
        }

        // POST: Seat/Delete/5
        [HttpPost]
        public ActionResult Delete(Seat collection,string where,int whereId)
        {
            try
            {
                var Seatmodel = _context.Seats.Where(x => x.Where == where).ToList();
                int Countseat = Seatmodel.Count(x => x.WhereID == whereId);
                var SeatList = Seatmodel.Where(x => x.WhereID == whereId).ToList();

                int Todelete = collection.Number;
                int start = Countseat - Todelete;

                for(int i=start+1;i<=Countseat;i++)
                {
                    int id = SeatList.FirstOrDefault(x => x.Number == i).Id;
                    var model = _context.Seats.Find(id);
                    _context.Seats.Remove(model);_context.SaveChanges();
                }

                return RedirectToAction("FromWhereList",new { where=where,whereId=whereId});
            }
            catch
            {
                return View();
            }
        }
    }
}
