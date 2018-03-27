using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class FloorAdminController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        
        // GET: FloorAdmin
        public ActionResult Index()
        {
            string AdminUserName = User.Identity.Name;
            int FloorId = _context.Admins.FirstOrDefault(x => x.Name == AdminUserName).PostId;

            ViewBag.Rooms = _context.Rooms.Count(x => x.FloorId == FloorId);
            ViewBag.Wards = _context.Wards.Count(x => x.FloorId == FloorId);
            ViewBag.ICU = _context.Icu.Count(x => x.FloorId == FloorId);
            ViewBag.Seats = _context.Seats.Count(x => x.FloorId == FloorId);

            var Seat = _context.Seats.Where(x => x.FloorId == FloorId).ToList();
            ViewBag.EmptySeat = Seat.Count(x => x.IsEmpty != "Empty");

            return View();
        }

        // GET: FloorAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FloorAdmin/Create
        public ActionResult CreateBill()
        {
            List<Patient> Patients = _context.Patients.ToList();
            ViewBag.Patientslist = new SelectList(Patients, "Id", "Name");

            return View();
        }

        // POST: FloorAdmin/Create
        [HttpPost]
        public ActionResult CreateBill(Bill collection)
        {
            try
            {
                collection.PatientName = _context.Patients.FirstOrDefault(x => x.Id == collection.PatientId).Name;
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Bill.Add(collection);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FloorAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FloorAdmin/Edit/5
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

        // GET: FloorAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FloorAdmin/Delete/5
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
