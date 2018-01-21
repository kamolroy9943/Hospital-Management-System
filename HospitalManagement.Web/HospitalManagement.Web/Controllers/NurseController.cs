using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class NurseController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: Nurse
        public ActionResult Index()
        {
            var model = _context.Nurses.ToList();
            return View(model);
        }

        // GET: Nurse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nurse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nurse/Create
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

        // GET: Nurse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Nurse/Edit/5
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

        // GET: Nurse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nurse/Delete/5
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
