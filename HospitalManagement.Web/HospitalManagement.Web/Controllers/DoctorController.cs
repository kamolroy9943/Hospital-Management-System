using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HospitalManagement.Web.Controllers
{
    public class DoctorController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();

        // GET: Doctor
        public ActionResult Index()
        {
            var model = _context.Doctors.ToList();
            return View(model);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(Doctor collection, HttpPostedFileBase ImageFile)
        {
            try
            {
                //TODO: Add insert logic here
                string filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                filename += DateTime.Now.ToString("yymmssfff") + extension;
                collection.ImagePath = "~/Images/Doctors/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/Doctors/"), filename);
                ImageFile.SaveAs(filename);

                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;
                collection.RetireDate = DateTime.Now;
                _context.Doctors.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
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

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
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
