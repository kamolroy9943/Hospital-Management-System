using HospitalManagement.Data;
using HospitalManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class OperationTheaterController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();

        // GET: OperationTheater
       

        public ActionResult FromBuildingDash(int id)
        {
            var model = _context.OpertionTheaters.Where(x => x.BuildingId == id).ToList();
            ViewBag.BuildingId = id;
            ViewBag.from = "Building";
            ViewBag.fromid = id;    
            return View(model);
        }

        public ActionResult FromFloorDash(int id)
        {
            ViewBag.FloorId = id;
            ViewBag.from = "Floor";
            ViewBag.fromid = id;
            var model = _context.OpertionTheaters.Where(x => x.FloorId == id).ToList();
            return View(model);
        }

        // GET: OperationTheater/Details/5
        public ActionResult Details(int id,string from,int fromid)
        {
            var model = _context.OpertionTheaters.Find(id);
            ViewBag.from = from;
            ViewBag.fromid = fromid;
            return View(model);
        }

        // GET: OperationTheater/Create
       

        public JsonResult GetFloorList(int BuildingId)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            List<Floor> FloorList = _context.Floors.Where(x => x.BuildingId == BuildingId).ToList();
            return Json(FloorList, JsonRequestBehavior.AllowGet);
        }


        // POST: OperationTheater/Create
        [HttpPost]
        public ActionResult Create(OperationTheater collection)
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

        // GET: OperationTheater/Create
        public ActionResult FromBuildingCreate(int id )
        {
            List<Floor> Floors = _context.Floors.Where(x => x.BuildingId == id).ToList();
            ViewBag.Floorlist = new SelectList(Floors, "Id", "FloorNumber");
            ViewBag.BuildingId = id;
            ViewBag.BuildingName = _context.Building.FirstOrDefault(x => x.Id == id).BuildingName;
            int CurrentOts = _context.OpertionTheaters.Count(x => x.BuildingId == id);
            ViewBag.CurrentOTs = CurrentOts;
            ViewBag.NextOT = CurrentOts + 1;

            return View();
        }



        public JsonResult GetCurrentOTs(int FloorId)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            int countOTs = _context.OpertionTheaters.Count(x => x.FloorId == FloorId);
            return Json(countOTs, JsonRequestBehavior.AllowGet);
        }
        // POST: OperationTheater/Create
        [HttpPost]
        public ActionResult FromBuildingCreate(OperationTheater collection,int BuildingId)
        {
            try
            {
                collection.BuildingId = BuildingId;
                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == BuildingId).BuildingName;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == collection.FloorId).FloorNumber;
                collection.OperationDone = 0;
                int CurrentOts = _context.OpertionTheaters.Count(x => x.FloorId == collection.FloorId);
                collection.Number = CurrentOts + 1;

                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.OpertionTheaters.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("FromBuildingDash","OperationTheater",new {id=BuildingId });
            }
            catch
            {
                return View();
            }
        }


        // GET: OperationTheater/Create
        public ActionResult FromFloorCreate(int id)
        {
            int countOTs = _context.OpertionTheaters.Count(x => x.FloorId==id);
            ViewBag.FloorId = id;
            ViewBag.BuildingId = _context.Floors.FirstOrDefault(x => x.Id == id).BuildingId;
            ViewBag.CurrentOts = countOTs;
            ViewBag.NextOt = countOTs + 1;
            return View();
        }

        // POST: OperationTheater/Create
        [HttpPost]
        public ActionResult FromFloorCreate(OperationTheater collection,int FloorId,int NextOt)
        {
            try
            {
                
                collection.FloorId = FloorId;
                collection.FloorNumber = _context.Floors.FirstOrDefault(x => x.Id == FloorId).FloorNumber;
                collection.BuildingId = _context.Floors.FirstOrDefault(x => x.Id == FloorId).BuildingId;
                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                collection.Number = NextOt;
                collection.OperationDone = 0;
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.OpertionTheaters.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("FromFloorDash","OperationTheater",new {id=collection.FloorId });
            }
            catch
            {
                return View();
            }
        }


        // GET: OperationTheater/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OperationTheater/Edit/5
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

        // GET: OperationTheater/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.OpertionTheaters.Find(id);
            return View(model);
        }

        // POST: OperationTheater/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OperationTheater collection,string from,int fromid)
        {
            try
            {
                var model=_context.OpertionTheaters.Find(id);
                _context.OpertionTheaters.Remove(model);
                _context.SaveChanges();
                string Return = "From" + from + "Dash";
                return RedirectToAction(Return,new {id=fromid });
            }
            catch
            {
                return View();
            }
        }
    }
}
