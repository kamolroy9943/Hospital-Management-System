using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Web.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Web.Controllers
{
    public class BuildingController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        
        // GET: Building
        public ActionResult Index()
        {
            var model = _context.Building.ToList();
            return View(model);
        }

        // Building DashBoard
        public ActionResult Dashboard()
        {

            return View();
        }

        // GET: Building/Details/5
        public ActionResult Details(int id)
        {
            Building B = _context.Building.Find(id);
            return View(B);
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Building/Create
        [HttpPost]
        public ActionResult Create(Building collection)
        {
            try
            {
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = Environment.UserName;

                _context.Building.Add(collection);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Building/Edit/5
        public ActionResult Edit(int id)
        {
             Building B = _context.Building.Find(id);
             return View(B);
        }

        // POST: Building/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Building collection)
        {
            try
            {
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = Environment.UserName;

                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Building/Delete/5
        public ActionResult Delete(int id)
        {
            Building B = _context.Building.Find(id);
            return View(B);
        }

        // POST: Building/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Building collection)
        {
            try
            {
                Building B = _context.Building.Find(id);
                _context.Building.Remove(B);
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
