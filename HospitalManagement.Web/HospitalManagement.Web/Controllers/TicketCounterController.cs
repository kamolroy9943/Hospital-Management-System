using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class TicketCounterController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: TicketCounter
        public ActionResult Index()
        {
            var model = _context.TicketCounter.ToList();
            return View(model);
        }

        public ActionResult FromBuildingDash(int id)
        {
            var model = _context.TicketCounter.Where(x => x.BuildingId == id).ToList();
            return View(model);
        }

        // GET: TicketCounter/Details/5
        public ActionResult Details(int id)
        {
            var model = _context.TicketCounter.Find(id);
            return View(model);
        }

        // GET: TicketCounter/Create
        public ActionResult Create()
        {
            List<Building> Buildings = _context.Building.ToList();
            ViewBag.Buildinglist = new SelectList(Buildings, "Id", "BuildingName");

            return View();
        }

        // POST: TicketCounter/Create
        [HttpPost]
        public ActionResult Create(Ticket_Counter collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == collection.BuildingId).BuildingName;
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.TicketCounter.Add(collection);
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
            ViewBag.BuildingName = _context.Building.FirstOrDefault(x => x.Id == id).BuildingName;
            ViewBag.BuildingId = id;
            return View();
        }

        // POST: TicketCounter/Create
        [HttpPost]
        public ActionResult FromBuildingCreate(Ticket_Counter collection,int BuildingId)
        {
            try
            {
                // TODO: Add insert logic here
                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == BuildingId).BuildingName;
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.TicketCounter.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("FromBuildingDash","TicketCounter",new {id=BuildingId });
            }
            catch
            {
                return View();
            }
        }


        // GET: TicketCounter/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _context.TicketCounter.Find(id);
            return View(model);
        }

        // POST: TicketCounter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Ticket_Counter collection)
        {
            try
            {
                // TODO: Add update logic here
                var model = _context.TicketCounter.Find(id);
                model.Number = collection.Number;
                model.Updated = DateTime.Now;
                model.UpdatedBy = User.Identity.Name;

                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Details",new {id=id });
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketCounter/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.TicketCounter.Find(id);
            return View(model);
        }

        // POST: TicketCounter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Ticket_Counter collection)
        {
            try
            {
                // TODO: Add delete logic here
                Ticket_Counter TicketCounter = _context.TicketCounter.Find(id);
                _context.TicketCounter.Remove(TicketCounter);
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
