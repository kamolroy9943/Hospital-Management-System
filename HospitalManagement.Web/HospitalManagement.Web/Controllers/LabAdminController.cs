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
        HospitalManagementContext _contex = new HospitalManagementContext();
        // GET: LabAdmin
        public ActionResult Index()
        {
            string AdminName = User.Identity.Name;
            int LabId = _contex.Admins.FirstOrDefault(x => x.Name == AdminName).PostId;

            ViewBag.LabId = LabId;

            return View();
        }

        //Get 
        public ActionResult CreateReport()
        {
            List<Patient> Patients = _contex.Patients.ToList();
            ViewBag.Patientlist = new SelectList(Patients, "Id", "Name");

            List<Doctor> Doctors = _contex.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "Id", "DoctorName");

            ViewBag.Status = "Not";
            return View();
        }

        // Create Report :POst 

        [HttpPost]
        public ActionResult CreateReport(LabReport collection)
        {
            collection.Updated = DateTime.Now;
            collection.UpdatedBy = User.Identity.Name;
            try
            {
                // Will be deleated
                collection.PatientName = _contex.Patients.FirstOrDefault(x => x.Id == collection.PatientID).Name;
                _contex.LabReport.Add(collection);
                _contex.SaveChanges();
                ViewBag.Status = "Yes";
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

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id,LabReport collection)
        {

            return View();
        }


    }
}