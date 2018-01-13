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

        public  ICollection<Floor> Floors { get; set; }

      //  public ICollection<Department> Departments { get; set; }

        //public ICollection<Ward> Wards { get; set; }

        //public ICollection<Lab> Labs { get; set; }

        //public ICollection<Ticket_Counter> Ticket_Counter { get; set; }

        //public ICollection<Patient> Patients { get; set; }
    }
}
