using HospitalManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Controllers
{
    [Authorize]
    public class usersController : Controller
    {
       
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
                else if (s[0].ToString() == "TicketAdmin")
                {
                    mark = 4;
                }
                else
                {
                    mark = 0;
                }
                
            }
            return mark;
        }


        // GET: Users
        public ActionResult Index()
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
                  return  RedirectToAction("Index", "SuperAdmin");
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
                if (mark == 4)
                {
                    //ViewBag.displayMenu = "Yes";
                    return RedirectToAction("Index", "TicketAdmin");
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
    
    }
}


/*
 using CopyAttendance.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CopyAttendance.Controllers
{
    [Authorize]
    public class userController : Controller
    {
        [Authorize]
        public class UsersController : Controller
        {
            // GET: Users
            public Boolean isAdminUser()
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = User.Identity;
                    ApplicationDbContext context = new ApplicationDbContext();
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var s = UserManager.GetRoles(user.GetUserId());
                    if (s[0].ToString() == "Admin")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            public ActionResult Index()
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = User.Identity;
                    ViewBag.Name = user.Name;
                    //	ApplicationDbContext context = new ApplicationDbContext();
                    //	var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                    //var s=	UserManager.GetRoles(user.GetUserId());
                    ViewBag.displayMenu = "No";

                    if (isAdminUser())
                    {
                        ViewBag.displayMenu = "Yes";
                    }
                    return View();
                }
                else
                {
                    ViewBag.Name = "Not Logged IN";
                }


                return View();


            }

        }
    }
}
 */