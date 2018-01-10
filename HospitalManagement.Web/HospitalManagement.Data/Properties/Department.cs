using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Department
    {
        [Key]
         public  int Id { get; set; }

        [Required]
        public  string Name { get; set; }

       // public Building Building { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
       

       // public Floor Floor { get; set; }
        public int FloorId { get; set; }
        public int FloorNumber { get; set; }
       


       // public IList<Building>Building { get; set; }

        //public ICollection<Ward> Wards { get; set; }

       // public IList<Floor>Floor { get; set; }

        public DateTime Updated { get; set; }
        public string updatedby { get; set; }

        //public ICollection<Patient> Patients { get; set; }

        //public ICollection<Doctor> Doctors { get; set; }

    }
}
