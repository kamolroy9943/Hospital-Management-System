using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class TreatmentController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: Treatment
        public ActionResult Index(int id)
        {
            var model = _context.Treatment.Where(x => x.PatientId == id).ToList();
            ViewBag.PatientId = id;
            int Count = _context.Treatment.Count(x => x.PatientId == id);
            if (Count == 0) ViewBag.Id = 0;
            else 
            ViewBag.Id = _context.Treatment.FirstOrDefault(x => x.PatientId == id).Id;

            return View(model);
        }

        // GET: Treatment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Treatment/Create
        public ActionResult Create(int id,int PatientId)
        {
            Treatment treatment = new Treatment();
            treatment.PatientId = PatientId;
            treatment.PatientName = _context.Patients.FirstOrDefault(x => x.Id == PatientId).Name;
            treatment.Date = DateTime.Today;

            List<Doctor> Doctors = _context.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "DoctorName", "DoctorName");

            return View(treatment);
        }

        // POST: Treatment/Create
        [HttpPost]
        public ActionResult Create(Treatment collection,int id, int PatientId)
        {
            try
            {
                // TODO: Add insert logic here
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;
                _context.Treatment.Add(collection);
                _context.SaveChanges();
                return RedirectToAction("Index",new {id=PatientId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Treatment/Edit/5
        public ActionResult Edit(int id)
        {
            List<Doctor> Doctors = _context.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "DoctorName", "DoctorName");
            var model = _context.Treatment.Find(id);
            return View(model);
        }

        // POST: Treatment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Treatment collection)
        {
            try
            {
                // TODO: Add update logic here
                collection.Id = id;
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index",new {id=collection.PatientId });
            }
            catch
            {
                return View();
            }
        }

        
    }
}
