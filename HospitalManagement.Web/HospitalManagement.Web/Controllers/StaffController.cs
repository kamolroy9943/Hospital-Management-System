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
        Staff_Category cat = new Staff_Category();
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
            List<Staff_Category> Categoryl = _context.StaffCategory.ToList();
            ViewBag.CategoryList = new SelectList(Categoryl, "CategoryName", "CategoryName");

            DateTime tt = DateTime.Parse("11/11/2000");
            var model = _context.Staffs.Where(x=>x.RetireDate==tt).ToList();
            return View(model);
        }

        public JsonResult GetList(string Category)
        {

            _context.Configuration.ProxyCreationEnabled = false;
            List<Staff> List = _context.Staffs.Where(x => x.Designation == Category).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RetiredList()
        {
            DateTime tt = DateTime.Parse("11/11/2000");
            var model = _context.Staffs.Where(x => x.RetireDate != tt).ToList();
            return View(model);
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            DateTime tt = DateTime.Parse("11/11/2000");
            var model = _context.Staffs.Find(id);
            int chk=0;
            if (model.RetireDate == tt) chk = 1;
            ViewBag.chk = chk;
            return View(model);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            List<Staff_Category> Category = _context.StaffCategory.ToList();
            ViewBag.CategoryList = new SelectList(Category, "CategoryName", "CategoryName");
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(Staff collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.Updated = DateTime.Today;
                collection.UpdatedBy = User.Identity.Name;
                
                DateTime tt =  DateTime.Parse("11/11/2000");
                collection.RetireDate = tt;
                _context.Staffs.Add(collection);_context.SaveChanges();

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
            List<Staff_Category> Category = _context.StaffCategory.ToList();
            ViewBag.CategoryList = new SelectList(Category, "CategoryName", "CategoryName");

            var model = _context.Staffs.Find(id);
            return View(model);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Staff collection)
        {
            try
            {
                // TODO: Add update logic here
                Staff Staff = new Staff();
                Staff.Name = collection.Name;
                Staff.Contact = collection.Contact;
                Staff.ContactNo = collection.ContactNo;
                Staff.ContactEmail = collection.ContactEmail;
                Staff.Salary = collection.Salary;
                Staff.Designation = collection.Designation;
                Staff.joinningDate = collection.joinningDate;
                Staff.Updated = DateTime.Today;
                Staff.UpdatedBy = User.Identity.Name;

                _context.Entry(Staff).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
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
            var model = _context.Staffs.Find(id);
            return View(model);
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Staff collection)
        {
            try
            {
                // TODO: Add delete logic here
                Staff staff = _context.Staffs.Find(id);
                staff.RetireDate = collection.RetireDate;
                staff.Updated = DateTime.Now;
                staff.UpdatedBy = User.Identity.Name;

                _context.Entry(staff).State = System.Data.Entity.EntityState.Modified;
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
