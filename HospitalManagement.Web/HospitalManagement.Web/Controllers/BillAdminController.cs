using HospitalManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class BillAdminController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: BillAdmin
        public ActionResult Index()
        {
            string AdminName = User.Identity.Name;
            int BuildingId = _context.Admins.FirstOrDefault(x => x.Name == AdminName).BuildingId;
            return View();
        }

        // GET: BillAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BillAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillAdmin/Create
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

        // GET: BillAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BillAdmin/Edit/5
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

        // GET: BillAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BillAdmin/Delete/5
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
