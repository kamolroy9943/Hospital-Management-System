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
        public int Id { get; set; }       
        [Required]
        public string DoctorName { get; set; }
        public int age { get; set; }

        public int Salary { get; set; }


        public string Contact { get; set; }
        public string ContactNo { get; set; }
        public string ContactEmail { get; set; }

        public string Departments { get; set; }
        public string Degrees { get; set; }

        public string SurgeryOrMedicine { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime JoinningDate { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime RetireDate { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }


        public string ImagePath { get; set; }
        

    }
}
