using System;
using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class StaffCategoryController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();

        // GET: StaffCategory
        public ActionResult Index()
        {
           

            var model = _context.StaffCategory.ToList();
            return View(model);
        }

        

        // GET: StaffCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffCategory/Create
        [HttpPost]
        public ActionResult Create(Staff_Category collection)
        {
            try
            {
                // TODO: Add insert logic here
                 collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.StaffCategory.Add(collection);_context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffCategory/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _context.StaffCategory.Find(id);
            return View(model);
        }

        // POST: StaffCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Staff_Category collection)
        {
            try
            {
                // TODO: Add update logic here
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffCategory/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.StaffCategory.Find(id);
            return View(model);
        }

        // POST: StaffCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Staff_Category collection)
        {
            try
            {
                // TODO: Add delete logic here
                Staff_Category model = _context.StaffCategory.Find(id);
                _context.StaffCategory.Remove(model);_context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
