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

        public virtual Building Building { set; get; }
        
        public virtual ICollection<Department>Departments { get; set; }

        public  virtual ICollection<Room>Rooms { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<Ward>Wards { get; set; }
        public ICollection<ICU> Icus { get; set; }
        public ICollection<Lab> Labs { get; set; }
        public ICollection<OperationTheater> OperationTheaters { get; set; }

        //public ICollection<Patient> Patients { get; set; }
    }
}
