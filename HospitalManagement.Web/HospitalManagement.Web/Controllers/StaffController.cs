using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class StaffController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: Staff
        public ActionResult Index()
        {
            int count = _context.StaffCategory.Count(x => x.CategoryName == "Nurse");
            if (count == 0)
            {
                Staff_Category Category = new Staff_Category();
                Category.Updated = DateTime.Now;
                Category.UpdatedBy = "Auto Generated";
                Category.CategoryName = "Nurse";
                _context.StaffCategory.Add(Category); _context.SaveChanges();
                Category.CategoryName = "Ward Boy";
                _context.StaffCategory.Add(Category); _context.SaveChanges();
                Category.CategoryName = "Accountant";
                _context.StaffCategory.Add(Category); _context.SaveChanges();
                Category.CategoryName = "Janitor";
                _context.StaffCategory.Add(Category); _context.SaveChanges();
                Category.CategoryName = "Admin";
                _context.StaffCategory.Add(Category); _context.SaveChanges();
                Category.CategoryName = "Guard";
                _context.StaffCategory.Add(Category); _context.SaveChanges();

            }
            var model = _context.Staffs.ToList();
            return View(model);
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
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

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/Edit/5
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

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/Delete/5
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
