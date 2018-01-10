using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Doctor
    {
        [Key]
       public int DoctorId { get; set; }

        
        [Required]
        public string Name { get; set; }
        public int age { get; set; }

        public string Degree { get; set; }

        public string Post { get; set; }
        
        public IList<Doctor_Department> Doctor_Department { get; set; }
        public IList<Department> Department { get; set; }

    }
}
