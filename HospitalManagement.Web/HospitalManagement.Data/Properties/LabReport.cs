using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
   public class LabReport
    {
        [Key]
        public int Id { get; set; }

        public int PatientID { get; set; }
        public string PatientName { get; set; }
       public Patient Patient { get; set; }
        public string TestName { get; set; }
        [Required]
        public  string Deatils { get; set; }
        [Required]
        

        public int Bill { get; set; }

        [Required]
        public string AuthorisedDoctor { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        

    }
}
