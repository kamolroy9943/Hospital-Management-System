using HospitalManagement.Data;
using HospitalManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class TicketAdminController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: TicketAdmin
        public ActionResult Index()
        {
            List<Building> Buildings = _context.Building.ToList();
            ViewBag.Buildinglist = new SelectList(Buildings, "Id", "BuildingName");

            return View();
        }

        public JsonResult GetCounterList(int BuildingId)
        {

            _context.Configuration.ProxyCreationEnabled = false;
            List<Ticket_Counter> List = _context.TicketCounter.Where(x => x.BuildingId==BuildingId).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(Ticket collection)
        {

            return RedirectToAction("Create","TicketAdmin",new {BuildingId=collection.BuildingId,CounterId=collection.Ticket_CounterId });
        }


        // GET: TicketAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketAdmin/Create
        public ActionResult Create(int BuildingId, int CounterId)
        {
            List<Department> Departments = _context.Departments.Where(x => x.BuildingId == BuildingId).ToList();
            ViewBag.Departmentlist = new SelectList(Departments, "Id", "Name");

            ViewBag.BuildingId = BuildingId;ViewBag.CounterId = CounterId;
            return View();
        }

        // POST: TicketAdmin/Create
        [HttpPost]
        public ActionResult Create(Ticket collection, int BuildingId, int CounterId)
        {
            try
            {
                // TODO: Add insert logic here

                collection.BuildingName = _context.Building.FirstOrDefault(x => x.Id == BuildingId).BuildingName;
                collection.BuildingId = BuildingId;
                collection.Ticket_CounterId = CounterId;
                collection.Ticket_CounterNumber = _context.TicketCounter.FirstOrDefault(x => x.Id == CounterId).Number;
                collection.DepartmentName = _context.Departments.FirstOrDefault(x => x.Id == collection.DepartmentId).Name;
               collection.IssuedTime = DateTime.Today;
                collection.IssuedBy = User.Identity.Name;

                var thisBuilding = _context.Tickets.Where(x => x.BuildingId == BuildingId).ToList();
                var thisDepartment = thisBuilding.Where(x => x.DepartmentId == collection.DepartmentId).ToList();
                int Sofartoday = thisDepartment.Count(x => x.IssuedTime == DateTime.Today);
                int next = Sofartoday + 1;
                collection.SerialNumber = next;

                _context.Tickets.Add(collection);_context.SaveChanges();
                

                return RedirectToAction("Create",new { BuildingId = collection.BuildingId, CounterId = collection.Ticket_CounterId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ShowTodays(int CounterId)
        {
            var model = _context.Tickets.Where(x => x.Ticket_CounterId == CounterId).ToList();
            var today = model.Where(x => x.IssuedTime == DateTime.Today).ToList();
            ViewBag.BuildingId = _context.TicketCounter.FirstOrDefault(x => x.Id == CounterId).BuildingId;
            ViewBag.CounterId = CounterId;
            return View(today);
        }

        
    }
}
