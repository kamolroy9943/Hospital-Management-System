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
            DateTime tt = DateTime.Parse("11/11/2000");
            var model = _context.Doctors.Where(x => x.RetireDate == tt).ToList();
            var model1 = model.OrderByDescending(x=>x.DoctorName).ToList();
           return View(model1);
        }

        public ActionResult RetiredList()
        {
            DateTime tt = DateTime.Parse("11/11/2000");
            var model = _context.Doctors.Where(x => x.RetireDate != tt).OrderByDescending(x => x.RetireDate).ToList();
            return View(model);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            var model = _context.Doctors.Find(id);
            return View(model);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {

            List<Department> Departments = _context.Departments.GroupBy(x => x.Name).Select(y => y.FirstOrDefault()).ToList();
            ViewBag.Departmentlist = new SelectList(Departments,"Id","Name");

            
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(Doctor collection,HttpPostedFileBase ImageFile)
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
                int DeptId = int.Parse(collection.Departments);
                collection.Departments = _context.Departments.FirstOrDefault(x => x.Id ==DeptId).Name;
                if(int.Parse(collection.SurgeryOrMedicine)==1)
                {
                    collection.SurgeryOrMedicine = "Surgery";
                }
                else { collection.SurgeryOrMedicine = "Medicine"; }
                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                DateTime tt = DateTime.Parse("11/11/2000");
                collection.RetireDate = tt;

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
            List<Department> Departments = _context.Departments.GroupBy(x => x.Name).Select(y => y.FirstOrDefault()).ToList();
            ViewBag.Departmentlist = new SelectList(Departments, "Id", "Name");

            var model = _context.Doctors.Find(id);
           string tt = model.JoinningDate.ToString("MM/dd/yyyy");
            DateTime ttt = DateTime.Parse(tt);
            model.JoinningDate = ttt;

            if(model.SurgeryOrMedicine=="Surgery")
            {
                model.SurgeryOrMedicine = "1";
            }
            else
            {
                model.SurgeryOrMedicine = "2";
            }


            ViewBag.Departments =  model.Departments;
            string DeptName = model.Departments;
            return View(model);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Doctor collection,HttpPostedFileBase ImageFile)
        {
            try
            {
                // TODO: Add update logic here
                var model = _context.Doctors.Find(id);
                if (ImageFile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    string extension = Path.GetExtension(ImageFile.FileName);
                    filename += DateTime.Now.ToString("yymmssfff") + extension;
                    collection.ImagePath = "~/Images/Doctors/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/Doctors/"), filename);
                    ImageFile.SaveAs(filename);
                }
                else { collection.ImagePath = model.ImagePath; }

                if (int.Parse(collection.SurgeryOrMedicine) == 1)
                {
                    collection.SurgeryOrMedicine = "Surgery";
                }
                else { collection.SurgeryOrMedicine = "Medicine"; }

                if (collection.Departments != null)
                {
                    string Departments = model.Departments;
                    int DeptId = int.Parse(collection.Departments);
                    string NewDepartment = _context.Departments.FirstOrDefault(x => x.Id == DeptId).Name;
                    Departments += ", " + NewDepartment;
                    collection.Departments = Departments;
                }
                else { collection.Departments = model.Departments; }

                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                DateTime tt = DateTime.Parse("11/11/2000");
                collection.RetireDate = tt;

                //model = collection;
                // _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.Doctors.Remove(model);
                _context.SaveChanges();
                _context.Doctors.Add(collection);

                _context.SaveChanges();
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
            var model = _context.Doctors.Find(id);
            return View(model);
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Doctor collection)
        {
            try
            {
                var model = _context.Doctors.Find(id);
                model.RetireDate = DateTime.Today;

                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
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
