using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Doctor_Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }
        

        public ICollection<Doctor> Doctors { get; set; }
    }
}
