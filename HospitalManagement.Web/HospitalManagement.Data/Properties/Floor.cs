using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public  class Floor
    {
        [Key]
         public int Id { get; set; }

        
        public int FloorNumber { get; set; }

        public int BuildingId { get; set; }

        public Building Building { set; get; }
        
       // public ICollection<Department>Departments { get; set; }

        //public ICollection<Room>Rooms { get; set; }

        //public ICollection<Ward>Wards { get; set; }

        //public ICollection<Lab> Labs { get; set; }

        //public ICollection<Patient> Patients { get; set; }
    }
}
