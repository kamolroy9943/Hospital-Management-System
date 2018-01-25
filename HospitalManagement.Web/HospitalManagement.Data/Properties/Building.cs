using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Building
    {
        [Key]
        public int Id  { get; set; }
        

        [Required]
        public string BuildingName { get; set; }

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; }       

        // Navigation Relation

        public  virtual ICollection<Floor> Floors { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public  virtual ICollection<Room>Rooms { get; set; }

        public ICollection<Ward> Wards { get; set; }
        public ICollection<Seat>Seats { get; set; }
        public ICollection<Lab> Labs { get; set; }
        public ICollection<ICU> Icu { get; set; }
        public ICollection<OperationTheater> OperationTheaters { get; set; }
        public ICollection<Ticket_Counter> Ticket_Counter { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

        //public ICollection<Patient> Patients { get; set; }
    }
}
