using HospitalManagement.Web.Models;
using HospitalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Hospital.Controllers
{
    public class SuperAdminController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: SuperAdmin
        public ActionResult Index()
        {
            

            return View();
        }
    }
}