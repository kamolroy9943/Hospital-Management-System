using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
   public class Lab_Report
    {
        [Key]
        public int Id { get; set; }

        public Guid PatientID { get; set; }
       
        public Guid FileID { get; set; }
        [Required]
        public string ReportName { get; set; }

        public double BillForReport { get; set; }

        [Required]
        public string IssuedBy { get; set; }

        

    }
}
