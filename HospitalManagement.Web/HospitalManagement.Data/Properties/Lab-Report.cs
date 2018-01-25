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

        public int PatientID { get; set; }
        public Patient Patient { get; set; }
       
        public int FileID { get; set; }
        [Required]
        public string ReportName { get; set; }

        public double BillForReport { get; set; }

                public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

    }
}
