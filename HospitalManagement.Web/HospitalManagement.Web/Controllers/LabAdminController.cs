using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Hospital.Controllers
{
    public class LabAdminController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: LabAdmin
        public ActionResult Index()
        {
            string AdminName = User.Identity.Name;
            int LabId = _context.Admins.FirstOrDefault(x => x.Name == AdminName).PostId;

            ViewBag.LabId = LabId;

            return View();
        }

        public ActionResult Reportlist()
        {
            var list = _context.LabReport.ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            return View(_context.LabReport.Find(id));
        }

        //Get 
        public ActionResult CreateReport()
        {
            List<Patient> Patients = _context.Patients.ToList();
            ViewBag.Patientlist = new SelectList(Patients, "Id", "Name");

            List<Doctor> Doctors = _context.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "DoctorName", "DoctorName");

            ViewBag.Status = "Not";
            return View();
        }

        // Create Report :POst 

        [HttpPost]
        public ActionResult CreateReport(LabReport collection)
        {
            List<Patient> Patients = _context.Patients.ToList();
            ViewBag.Patientlist = new SelectList(Patients, "Id", "Name");

            List<Doctor> Doctors = _context.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "DoctorName", "DoctorName");
            collection.Updated = DateTime.Now;
            collection.UpdatedBy = User.Identity.Name;
            try
            {
                // Will be deleated
                
                collection.PatientName = _context.Patients.FirstOrDefault(x => x.Id == collection.PatientId).Name;
                _context.LabReport.Add(collection);
                _context.SaveChanges();
                ViewBag.Status = "Yes";

                Bill bill = new Bill();
                bill.WhatFor = "Lab test :  " + collection.TestName;
                bill.Description = collection.Deatils;
                bill.PatientId = collection.PatientId;
                bill.PatientName = collection.PatientName;
                bill.Amount = collection.Bill;
                bill.Updated = DateTime.Now;
                bill.UpdatedBy = User.Identity.Name;
                _context.Bill.Add(bill);_context.SaveChanges();
                return View(collection);
        }
            catch
            {
                ViewBag.Status = "Not";
                return View(collection);
    }

}

        public ActionResult Edit (int id)
        {
            List<Patient> Patients = _context.Patients.ToList();
            ViewBag.Patientlist = new SelectList(Patients, "Id", "Name");

            List<Doctor> Doctors = _context.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "DoctorName", "DoctorName");
            LabReport labReport = _context.LabReport.Find(id);
            return View(labReport);
        }

        [HttpPost]
        public ActionResult Edit(int id,LabReport collection)
        {
            try
            {
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;
                
                collection.PatientName = _context.Patients.FirstOrDefault(x => x.Id == collection.PatientId).Name;

                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                
                return RedirectToAction("Reportlist");
            }
            catch { return View(); }
        }


    }
}