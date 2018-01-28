using HospitalManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index","users");
            //}
            return View();
        }
        //..........................................................................


            public ActionResult Check()
        {
            if (User.Identity.IsAuthenticated)
            {
                int mark = 0;
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";
                mark = isAdminUser();
                if (mark == 1)
                {
                    //ViewBag.displayMenu = "Yes";
                    return RedirectToAction("Index", "SuperAdmin");
                }
                if (mark == 2)
                {
                    //ViewBag.displayMenu = "Yes";
                    return RedirectToAction("Index", "FloorAdmin");
                }
                if (mark == 3)
                {
                    //ViewBag.displayMenu = "Yes";
                    return RedirectToAction("Index", "LabAdmin");
                }

                //return View();
            }
            else
            {
                return RedirectToAction("Contact", "Home");
                //ViewBag.Name = "Not Logged IN";
            }

            return View();
        }




        public int isAdminUser()
        {
            int mark = 0;
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());

                if (s[0].ToString() == "SuperAdmin")
                {
                    mark = 1;
                }
                else if (s[0].ToString() == "FloorAdmin")
                {
                    mark = 2;
                }
                else if (s[0].ToString() == "LabAdmin")
                {
                    mark = 3;
                }
                else
                {
                    mark = 0;
                }

            }
            return mark;
        }

        //......................................................................

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}