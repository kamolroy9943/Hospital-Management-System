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

        
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

    }
}
