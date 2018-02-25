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
    [Authorize(Roles ="FloorAdmin")]
    public class PatientController : Controller
    {
        HospitalManagementContext _context = new HospitalManagementContext();
        // GET: Patient
        public ActionResult AllPatientIndex(string Where)
        {
            if(Where=="Room")
            {
                DateTime tt = DateTime.Parse("11/11/2000");
                ViewBag.Where = "Room";
                var model = _context.Patients.Where(x => x.Where == "Room").Where(y=>y.ReleaseDate==tt).ToList();
                return View(model);
            }
            else if(Where=="Ward")
            {
                DateTime tt = DateTime.Parse("11/11/2000");
                ViewBag.Where = "Ward";
                var model = _context.Patients.Where(x => x.Where == "Ward").Where(y => y.ReleaseDate == tt).ToList();
                return View(model);
            }
            else if(Where=="ICU")
            {
                DateTime tt = DateTime.Parse("11/11/2000");
                ViewBag.Where = "ICU";
                var model = _context.Patients.Where(x => x.Where == "ICU").Where(y => y.ReleaseDate == tt).ToList();
                return View(model);
            }

            return View();
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            Patient patient = _context.Patients.Find(id);
            return View(patient);
        }

        // GET: Patient/Create -> In Room
        public ActionResult CreateInRoom()
        {
            string AdminName = User.Identity.Name;
            int FloorId = _context.Admins.FirstOrDefault(x => x.Name == AdminName).PostId;

            
            List<Room> Rooms = _context.Rooms.Where(x => x.FloorId == FloorId).ToList();
            ViewBag.Roomlist = new SelectList(Rooms, "Id", "RoomNumber");

            

            List<Doctor> Doctors = _context.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "DoctorName", "DoctorName");

            return View();
        }

        public JsonResult GetSeatList(int WhereId, string Where)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var SeatRoom = _context.Seats.Where(x => x.Where == Where).ToList();

            List<Seat> SeatList = SeatRoom.Where(x => x.WhereID == WhereId).Where(y => y.IsEmpty == "Empty").ToList();
            return Json(SeatList, JsonRequestBehavior.AllowGet);
        }

        // POST: Patient/Create -> In Room
        [HttpPost]
        public ActionResult CreateInRoom(Patient collection, HttpPostedFileBase ImageFile)
        {
            try
            {
                // TODO: Add insert logic here
                string filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                filename += DateTime.Now.ToString("yymmssfff") + extension;
                collection.ImagePath = "~/Images/Patients/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/Patients/"), filename);
                ImageFile.SaveAs(filename);
               

                collection.Where = "Room";
                DateTime tt = DateTime.Parse("11/11/2000");
                collection.ReleaseDate = tt;

                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Patients.Add(collection);
                _context.SaveChanges();

                int BookSeat = _context.Seats.Where(x => x.Where == "Room").FirstOrDefault(y => y.Number==collection.SeatNumber).Id;
                Seat Seat = _context.Seats.Find(BookSeat);
                Seat.IsEmpty = "Patient : " + collection.Name;
                Seat.HasbeenUsed = Seat.HasbeenUsed + 1;
                _context.Entry(Seat).State = System.Data.Entity.EntityState.Modified;_context.SaveChanges();

                return RedirectToAction("AllPatientIndex",new {Where="Room" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Create -> In Room
        public ActionResult CreateInICU()
        {
            string AdminName = User.Identity.Name;
            int ICUId = _context.Admins.FirstOrDefault(x => x.Name == AdminName).PostId;


            List<Seat> Seats = _context.Seats.Where(x => x.Where == "ICU").Where(y => y.WhereID == ICUId).Where(z=>z.IsEmpty=="Empty").ToList();
            ViewBag.Seatlist = new SelectList(Seats, "Number", "Number");



            List<Doctor> Doctors = _context.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "DoctorName", "DoctorName");
            return View();
        }

        // POST: Patient/Create -> In Room
        [HttpPost]
        public ActionResult CreateInICU(Patient collection, HttpPostedFileBase ImageFile)
        {
            try
            {
                // TODO: Add insert logic here
                string filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                filename += DateTime.Now.ToString("yymmssfff") + extension;
                collection.ImagePath = "~/Images/Patients/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/Patients/"), filename);
                ImageFile.SaveAs(filename);


                collection.Where = "ICU";
                DateTime tt = DateTime.Parse("11/11/2000");
                collection.ReleaseDate = tt;

                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Patients.Add(collection);
                _context.SaveChanges();

                int BookSeat = _context.Seats.Where(x => x.Where == "ICU").FirstOrDefault(y => y.Number == collection.SeatNumber).Id;
                Seat Seat = _context.Seats.Find(BookSeat);
                Seat.IsEmpty = "Patient : " + collection.Name;
                Seat.HasbeenUsed = Seat.HasbeenUsed + 1;
                _context.Entry(Seat).State = System.Data.Entity.EntityState.Modified; _context.SaveChanges();

                return RedirectToAction("AllPatientIndex", new { Where = "ICU" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Create -> In Room
        public ActionResult CreateInWard()
        {
            string AdminName = User.Identity.Name;
            int FloorId = _context.Admins.FirstOrDefault(x => x.Name == AdminName).PostId;


            List<Ward> Wards = _context.Wards.Where(x => x.FloorId == FloorId).ToList();
            ViewBag.Wardlist = new SelectList(Wards, "Id", "Name");



            List<Doctor> Doctors = _context.Doctors.ToList();
            ViewBag.Doctorlist = new SelectList(Doctors, "DoctorName", "DoctorName");
            return View();
        }

        // POST: Patient/Create -> In Room
        [HttpPost]
        public ActionResult CreateInWard(Patient collection, HttpPostedFileBase ImageFile)
        {
            try
            {
                // TODO: Add insert logic here
                // TODO: Add insert logic here
                string filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                filename += DateTime.Now.ToString("yymmssfff") + extension;
                collection.ImagePath = "~/Images/Patients/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/Patients/"), filename);
                ImageFile.SaveAs(filename);


                collection.Where = "Ward";
                DateTime tt = DateTime.Parse("11/11/2000");
                collection.ReleaseDate = tt;

                collection.Updated = DateTime.Now;
                collection.UpdatedBy = User.Identity.Name;

                _context.Patients.Add(collection);
                _context.SaveChanges();

                int BookSeat = _context.Seats.Where(x => x.Where == "Ward").FirstOrDefault(y => y.Number == collection.SeatNumber).Id;
                Seat Seat = _context.Seats.Find(BookSeat);
                Seat.IsEmpty = "Patient : " + collection.Name;
                Seat.HasbeenUsed = Seat.HasbeenUsed + 1;
                _context.Entry(Seat).State = System.Data.Entity.EntityState.Modified; _context.SaveChanges();

                return RedirectToAction("AllPatientIndex", new { Where = "Ward" });
            }
            catch
            {
                return View();
            }
        }

        

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Patient collection)
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

        // GET: Patient/Release/5
        public ActionResult Release(int id)
        {
            Patient patient = _context.Patients.Find(id);
            return View(patient);
        }

        // POST: Patient/Release/5
        [HttpPost]
        public ActionResult Release(int id, Patient collection)
        {
            try
            {
                // TODO: Add delete logic here
                Patient patient = _context.Patients.Find(id);
                patient.ReleaseDate = DateTime.Today;
                _context.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                Seat seat = _context.Seats.Where(x => x.Where == patient.Where).Where(y => y.WhereID == patient.WhereId).Where(z => z.Number == patient.SeatNumber).First();
                seat.IsEmpty = "Empty";
                _context.Entry(seat).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("AllPatientIndex",new {Where=patient.Where });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Treatment(int id)
        {

            return RedirectToAction("Index", "Treatment", new { id = id });

        }
    }
}
