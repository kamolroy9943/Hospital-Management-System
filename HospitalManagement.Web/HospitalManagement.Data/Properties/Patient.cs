using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
   public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string History { get; set; }

        [Required]
        public DateTime AdmitDate { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string RefferedBy_DoctorId { get; set; }
        
        public IList<Department> Department { get; set; }

        public IList<Building>Building { get; set; }

        public IList<Floor> Floor { get; set; }

        public IList<Ward> Ward { get; set; }

        public Seat Seat { get; set; }
        
      

        [Required]
        public string IssuedBy { get; set; }

    }
}
