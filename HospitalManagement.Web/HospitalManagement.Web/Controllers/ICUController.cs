using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class ICUController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();

        // GET: ICU
        public ActionResult Index()
        {
            var model = _context.Icu.ToList();
            return View(model);
        }

        // GET: ICU/Details/5
        public ActionResult Details(int id)
        {
            var IcuSeat = _context.Seats.Where(x => x.Where == "ICU").ToList();
            var CountSeat = IcuSeat.Count(x => x.WhereID == id);
            ViewBag.IcuId = id;
            ViewBag.CountSeat = CountSeat;
            ICU model = _context.Icu.Find(id);
            return View(model);
        }

        public ActionResult ICUToDelete(int whereId)
        {
            return RedirectToAction("Delete", "Seat", new { where = "ICU", whereId = whereId });
        }

        public ActionResult ICUToSeatList(int whereId)
        {

            return RedirectToAction("FromWhereList", "Seat", new {where="ICU",whereId=whereId });
        }

        public ActionResult ICUToCreate(int whereId)
        {
            return RedirectToAction("WhereCreate", "Seat", new { where = "ICU", whereId = whereId });
        }

        public ActionResult FromBuildingDetails(int id)
        {
            var IcuSeat = _context.Seats.Where(x => x.Where == "ICU").ToList();
            var CountSeat = IcuSeat.Count(x => x.WhereID == id);
            ViewBag.IcuId = id;
            ViewBag.CountSeat = CountSeat;

            ICU model = _context.Icu.FirstOrDefault(x => x.BuildingId == id);
            return View(model);
        }


        // GET: ICU/Create
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



        // POST: ICU/Create
        [HttpPost]
        public ActionResult Create(ICU collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                collection.ICUName = collection.BuildingName + " - ICU";
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Icu.Add(collection);
                _context.SaveChanges();


                return RedirectToAction("Index");
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
            ViewBag.BuildingId = id;
            return View();
        }

        // POST: ICU/Create
        [HttpPost]
        public ActionResult FromBuildingCreate(ICU collection,int BuildingId)
        {
            try
            {
                // TODO: Add insert logic here
                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == BuildingId).BuildingName;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x =>x.Id == collection.FloorId).FloorNumber;
                collection.ICUName = collection.BuildingName + " - ICU";
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Icu.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("Details","Building",new {id=BuildingId });
            }
            catch
            {
                return View();
            }
        }

        // GET: ICU/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ICU/Edit/5
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

        // GET: ICU/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.Icu.Find(id);
            return View(model);
        }

        // POST: ICU/Delete/5
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
