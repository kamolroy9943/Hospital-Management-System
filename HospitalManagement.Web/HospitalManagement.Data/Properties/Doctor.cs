using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;


namespace HospitalManagement.Data
{
    public class Doctor
    {
        [Key]
<<<<<<< HEAD
        public int Id { get; set; }
=======
        public int Id { get; set; }       
>>>>>>> 599b35c51d318bc2e4a9728b57421af77d5a8c58
        [Required]
        public string DoctorName { get; set; }
        public int age { get; set; }

<<<<<<< HEAD
=======
        public int Salary { get; set; }
>>>>>>> 599b35c51d318bc2e4a9728b57421af77d5a8c58


        public string Contact { get; set; }
        public string ContactNo { get; set; }
        public string ContactEmail { get; set; }

        public string Departments { get; set; }
        public string Departmentslist { get; set; }
        public string Degrees { get; set; }

        public string SurgeryOrMedicine { get; set; }

<<<<<<< HEAD

=======
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
>>>>>>> 599b35c51d318bc2e4a9728b57421af77d5a8c58
        [DataType(DataType.Date)]
        public DateTime JoinningDate { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime RetireDate { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }


        public string ImagePath { get; set; }
<<<<<<< HEAD

=======
        
>>>>>>> 599b35c51d318bc2e4a9728b57421af77d5a8c58

    }
}
