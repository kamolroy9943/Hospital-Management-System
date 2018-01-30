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
        HospitalManagementContext _contex = new HospitalManagementContext();
        public string FloorId;
        // GET: FloorAdmin
        public ActionResult Index()
        {
            var model = _contex.Building.ToList();
            return View(model);
        }

        // GET: FloorAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FloorAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FloorAdmin/Create
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
