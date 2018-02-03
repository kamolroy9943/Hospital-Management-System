using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class DoctorScheduleController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: DoctorSchedule
        public ActionResult Index()
        {
            var model = _context.DoctorsSchedule.ToList();
            return View(model);
        }

        // GET: DoctorSchedule/Details/5
        public ActionResult Details(int id)
        {
            var model = _context.DoctorsSchedule.Find(id);
            return View(model);
        }

        

        // GET: DoctorSchedule/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _context.DoctorsSchedule.Find(id);
            return View(model);
        }

        // POST: DoctorSchedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DoctorSchedule collection)
        {
            try
            {
                // TODO: Add update logic here
                DoctorSchedule Schedule = _context.DoctorsSchedule.Find(id);
                Schedule.Schedule = collection.Schedule;
                Schedule.Updated = DateTime.Today;
                Schedule.UpdatedBy = User.Identity.Name;
                _context.Entry(Schedule).State = System.Data.Entity.EntityState.Modified;
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
