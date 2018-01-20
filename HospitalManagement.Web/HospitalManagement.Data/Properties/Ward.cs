using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
   public class Ward
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public int FloorId { get; set; }
        public int FloorNumber { get; set; }
        public Floor Floor { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Department Department { get; set; }

        public DateTime Updated { get; set; }
        public string Updatedby { get; set; }


        //public IList<Building>Building { get; set; }

        //public IList<Department>Department { get; set; }   

        //public IList<Floor>Floor { get; set; }

        //public ICollection<Seat>Seats { get; set; }

        //public ICollection<Patient> Patients { get; set; }

    }
}
